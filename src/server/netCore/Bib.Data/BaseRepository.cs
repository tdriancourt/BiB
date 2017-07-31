using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Bib.Domain.Repositories;
using Bib.Domain.Model;
using System.Diagnostics.Contracts;

namespace Bib.Data
{
    public abstract class BaseRepository<T> : IRepository<T>
    where T : class, IEntity
    {
        protected BibContext Context;

        public BaseRepository(BibContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Contract.Requires(entity != null);
            Context.Add(entity);
        }

        protected IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return Context.Set<T>()
                .Where(e => e.Id == id).Single();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToListAsync().Result;
        }

        public void Remove(T entity)
        {
            Contract.Requires(entity != null);
            Context.Remove(entity);
        }
    }
}