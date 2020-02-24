using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CrmApiLogic.ApiModels;

namespace CrmApiLogic.Interfaces
{
    public interface IWorkedHoursRepository : IRepository<CrmApiLogic.Models.Projects.WorkedHour>
    {
        /// <summary>
        /// Get the total amout of hours spent on a project and the amount of money earned. ProjectId is the only mandatory paramenter.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<List<Report>> GetReport(int year, int? month, Guid? projectId);

        Task<MemoryStream> CreateCsvFile(Guid projectId, int year, int month);
    }
}
