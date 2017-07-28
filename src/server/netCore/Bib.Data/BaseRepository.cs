using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Bib.Domain.Repositories;
using Bib.Domain.Model;
using System.Threading.Tasks;

namespace Bib.Data
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected BibContext Context;
        
        public BaseRepository(BibContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException("entity");
                
                Context.Add(entity);
        }

        public abstract IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        public abstract T Get(int id);
        
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToListAsync().Result;
        }
        
        public void Remove(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException("entity");
                
            Context.Remove(entity);
        }
    }

    public abstract class BaseAsyncRepository<T> : BaseRepository<T> where T : class
    {
        public BaseAsyncRepository(BibContext context) : base(context)
        {}

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public abstract Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        public abstract Task<T> GetAsync(int id);
    }
}