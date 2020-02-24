using System;
using System.Linq;
using System.Threading.Tasks;
using CrmApiLogic.ApiModels;
using CrmApiLogic.Interfaces;
using CrmApiLogic.Models.Projects;
using CrmApiLogic.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrmApiLogic.Repositories
{
    public class ProjectsRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectsRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override Task<Project> GetById(Guid Id)
        {
            return DbContext.Projects.Where(w => w.Id==Id)
                                .Join(DbContext.Customers
                                , p => p.CustomerId
                                , c => c.Id
                                , (p, c) => new { p, c })
                                .Select(s => new Project
                                {
                                    Id = s.p.Id,
                                    Name = s.p.Name,
                                    StartDate = s.p.StartDate,
                                    EndDate = s.p.EndDate,
                                    TotalAmount = s.p.TotalAmount,
                                    HourlyRate = s.p.HourlyRate,
                                    CustomerId = s.p.CustomerId,
                                    Deleted = s.p.Deleted,
                                    Customer = new CrmApiLogic.Models.Customers.Customer
                                    {
                                        Id = s.c.Id,
                                        CompanyName = s.c.CompanyName,
                                        CEOName = s.c.CEOName,
                                        City = s.c.City,
                                        Deleted = s.c.Deleted,
                                        Email = s.c.Email,
                                        Country = s.c.Country,
                                        PhoneNumber = s.c.PhoneNumber,
                                        Town = s.c.Town,
                                        VAT = s.c.VAT
                                    }
                                })
                                .FirstOrDefaultAsync();

        }
    }
}
