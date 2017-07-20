using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Bib.Domain.Repository;

namespace Bib.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext Context;
        
        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException("entity");
                
                Context.Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException("entity");
                
            Context.Remove(entity);
        }
    }
}