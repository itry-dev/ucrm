using System;
using System.Linq;
using CrmApiLogic.Models;

namespace CrmApiLogic
{
    public static class LinqExtensions
    {
        public static IQueryable<TEntity> ApplyPagination<TEntity>(this IQueryable<TEntity> query, int page, int rowsPerPage) where TEntity : class
        {
            return query.Skip((page - 1 < 0 ? 0 : page - 1) * rowsPerPage).Take(rowsPerPage);
        }

        public static IQueryable<TEntity> FilterByDeleted<TEntity>(this IQueryable<TEntity> query) where TEntity : BaseModel
        {
            return query.Where(w => !w.Deleted);
        }
    }
}
