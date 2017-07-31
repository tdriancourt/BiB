using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bib.Domain.Model;

namespace Bib.Domain.Repositories
{
    public interface IAsyncRepository<T> : IRepository<T>
    where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(int id);
    }
}