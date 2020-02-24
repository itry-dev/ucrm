using System;
using System.Threading.Tasks;
using CrmApiLogic.Models.Customers;

namespace CrmApiLogic.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByProjectId(Guid projectId);

    }
}
