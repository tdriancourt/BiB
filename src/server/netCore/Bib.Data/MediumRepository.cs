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
    public class MediumRepository : BaseAsyncRepository<Medium>, IMediumRepository
    {
        public MediumRepository(BibContext context) : base(context)
        {
        }

        public Task<int> GetOverduesCountAsync(int loanDuration)
        {
            var limitDate = DateTime.Now.AddDays(-loanDuration);
            return this.Context.Borrow.Where(b => b.BorrowDate < limitDate && !b.ReturnDate.HasValue)
            .CountAsync();
        }
    }
}