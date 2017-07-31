using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Bib.Domain.Model;
using System.Threading.Tasks;

namespace Bib.Data
{
    public abstract class BaseAsyncRepository<T> : BaseRepository<T> 
    where T : class, IEntity
    {
        public BaseAsyncRepository(BibContext context) : base(context)
        {}

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        { 
            return await Context.Set<T>().Where(e => e.Id == id).SingleAsync();
        }
    }
}