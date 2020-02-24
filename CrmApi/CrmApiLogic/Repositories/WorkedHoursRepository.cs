using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CrmApiLogic.ApiModels;
using CrmApiLogic.Models.Projects;
using Microsoft.EntityFrameworkCore;

namespace CrmApiLogic.Repositories
{
    public class WorkedHoursRepository : GenericRepository<CrmApiLogic.Models.Projects.WorkedHour>, CrmApiLogic.Interfaces.IWorkedHoursRepository
    {
        public WorkedHoursRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<MemoryStream> CreateCsvFile(Guid projectId, int year, int month)
        {
            var projSpec = new CrmApiLogic.Specifications.Project.FindProject(projectId);
            var projList = await new CrmApiLogic.Repositories.ProjectsRepository(DbContext).ListAsync(projSpec);

            if (projList == null || projList.Count == 0)
            {
                return await Task.FromException<MemoryStream>(new Exception("Project not found"));
            }

            var project = projList.ElementAt(0);

            var spec = new CrmApiLogic.Specifications.Project.GetWorkedHoursList(new List<Guid> { projectId }, year, month);
            var list = await ListAsync(spec);

            decimal totalAmount = 0;

            using (var ms = new System.IO.MemoryStream())
            {
                using (var writer = new System.IO.StreamWriter(ms))
                {
                    using (var csv = new CsvHelper.CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        bool headerWritten = false;

                        foreach (var wh in list)
                        {
                            if (!headerWritten)
                            {
                                csv.WriteField(project.Customer.CompanyName);
                                csv.NextRecord();
                                csv.NextRecord();

                                csv.WriteField("Date");
                                csv.WriteField("Hours");
                                csv.WriteField("Hourly Day Rate");
                                csv.WriteField("Project Hourly Day Rate");
                                csv.WriteField("At customer office");
                                csv.WriteField("Notes");

                                csv.NextRecord();

                                headerWritten = true;
                            }

                            csv.WriteField(wh.Date.ToString("dddd d MMMM yyyy"));
                            csv.WriteField(wh.Hours);

                            csv.WriteField(wh.HourlyRate.HasValue && wh.HourlyRate.Value > 0 ? wh.HourlyRate.ToString() : String.Empty);
                            csv.WriteField(!wh.HourlyRate.HasValue || wh.HourlyRate.Value == 0 ? project.HourlyRate.ToString() : String.Empty);
                            csv.WriteField(wh.AtCustomerOffice);
                            csv.WriteField(wh.AdditionalNotes);

                            if (wh.HourlyRate.HasValue)
                            {
                                totalAmount += wh.HourlyRate.Value * Convert.ToDecimal(wh.Hours);
                            }
                            else
                            {
                                totalAmount += project.HourlyRate.Value *   Convert.ToDecimal(wh.Hours);
                            }

                            csv.NextRecord();
                        }

                        csv.NextRecord();
                        csv.WriteField($"Total amount {totalAmount}");
                        csv.NextRecord();

                        csv.Flush();
                    }
                }

                return await Task.FromResult<MemoryStream>(ms);
            }

        }

        public async Task<List<Report>> GetReport(int year, int? month, Guid? projectId)
        {
            var query = DbContext.WorkedHours.Where(w => w.Date.Year == year);

            if (month.HasValue)
            {
                query = query.Where(w => w.Date.Month == month.Value);
            }

            if (projectId.HasValue)
            {
                query = query.Where(w => w.ProjectId == projectId.Value);
            }

            return await query.Join(DbContext.Projects,
                w => w.ProjectId
                , p => p.Id
                , (w, p) => new { w.Hours, w.HourlyRate, ProjectId = p.Id, p.CustomerId, ProjectName = p.Name, pHourlyRate = p.HourlyRate })
                .Join(DbContext.Customers,
                join1 => join1.CustomerId
                , c => c.Id
                , (join1, c) => new { join1, c.CompanyName })
                .OrderBy(o => o.join1.Hours)
                .GroupBy(x => new { x.join1.ProjectName, x.CompanyName, x.join1.ProjectId })
                .Select(s => new Report
                {
                    Hours = s.Sum(s => s.join1.Hours),
                    TotalAmount = s.Sum(s => s.join1.Hours * (s.join1.HourlyRate.HasValue ? Convert.ToDouble(s.join1.HourlyRate.Value) : Convert.ToDouble(s.join1.pHourlyRate.Value))),
                    ProjectName = s.Key.ProjectName,
                    ProjectId = s.Key.ProjectId.ToString(),
                    CompanyName = s.Key.CompanyName
                }).ToListAsync();
            
        }

    }
}
