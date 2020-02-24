using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CrmApiLogic.Interfaces;
using CrmApiLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmApiLogic.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly DataContext DbContext;

        public GenericRepository(DataContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<int> Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            DbContext.Entry(entity).State = EntityState.Added;
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> Delete(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Deleted;
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> Delete(Guid Id)
        {
            var entity = DbContext.Set<T>().Where(w => w.Id == Id).FirstOrDefault();
            if (entity != default(T))
            {
                DbContext.Set<T>().Remove(entity);                
            }
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> Edit(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            return await DbContext.SaveChangesAsync();
        }

        public bool Exists(Guid id)
        {
            return DbContext.Set<T>().Any(e => e.Id == id);
        }

        public virtual Task<T> GetById(Guid Id)
        {
            return DbContext.Set<T>().Where(w => w.Id == Id).FirstOrDefaultAsync();
        }

        public virtual Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            var query = spec.Includes.Aggregate(DbContext.Set<T>().AsQueryable()
                , (current, include) => current.Include(include));

            query = spec.IncludeStrings.Aggregate(query
                , (current, include) => current.Include(include));

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            // Apply ordering if expressions are set
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.GroupBy != null)
            {
                query = query.GroupBy(spec.GroupBy).SelectMany(x => x);
            }

            // Apply paging if enabled
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip)
                             .Take(spec.Take);
            }

            return query/*.Where(spec.Criteria)*/.ToListAsync();
        }

        
    }
}
