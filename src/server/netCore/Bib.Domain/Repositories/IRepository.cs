using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bib.Domain.Model;

namespace Bib.Domain.Repositories
{
    public interface IRepository<T>
    where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Remove(T entity);
    }
}