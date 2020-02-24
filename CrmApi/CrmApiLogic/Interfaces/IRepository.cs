using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CrmApiLogic.Models;

namespace CrmApiLogic.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> GetById(Guid Id);

        Task<List<T>> ListAsync(ISpecification<T> spec);

        Task<int> Add(T entity);

        Task<int> Delete(T entity);

        Task<int> Delete(Guid Id);

        Task<int> Edit(T entity);

        bool Exists(Guid id);

    }
}
