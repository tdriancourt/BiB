using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class BorrowRepository : BaseAsyncRepository<Borrow>, IBorrowRepository
    {
        public BorrowRepository(BibContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Borrow>> GetOverduesAsync(int borrowingDuration)
        {
            return await Context.Borrow.Where(b => Convert.ToDateTime(b.BorrowDate).AddDays(borrowingDuration) > DateTime.Now).ToListAsync();
        }
     
        public async Task<int> GetOverduesCountAsync(int borrowingDuration)
        {
            return await Context.Borrow.Where(b => Convert.ToDateTime(b.BorrowDate).AddDays(borrowingDuration) > DateTime.Now).CountAsync();
        }
    }
}