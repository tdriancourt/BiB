using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bib.Domain.Repository
{
    public interface IRepository<T>
    where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Remove(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}