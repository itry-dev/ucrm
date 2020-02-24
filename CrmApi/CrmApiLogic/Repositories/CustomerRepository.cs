using System;
using System.Linq;
using System.Threading.Tasks;
using CrmApiLogic.Interfaces;
using CrmApiLogic.Models.Customers;
using Microsoft.EntityFrameworkCore;

namespace CrmApiLogic.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Customer> GetByProjectId(Guid projectId)
        {
            return await DbContext.Customers.Join(DbContext.Projects,
                c => c.Id
                , p => p.CustomerId
                , (c, p) => new { c })
                .Select(s => new Customer
                {
                    Id=s.c.Id,
                    CEOName=s.c.CEOName,
                    City=s.c.City,
                    CompanyName=s.c.CompanyName,
                    Country=s.c.Country,
                    Deleted=s.c.Deleted,//TODO remove, no support for logical cancellations 
                    Email=s.c.Email,
                    PhoneNumber=s.c.PhoneNumber,
                    Town=s.c.Town,
                    VAT=s.c.VAT
                })
                .FirstOrDefaultAsync();
        }

        public override Task<int> Delete(Guid Id)
        {
            return base.Delete(Id);
        }
    }
}
