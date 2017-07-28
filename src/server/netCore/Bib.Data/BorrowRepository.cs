using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class BorrowRepository : BaseRepository<Borrow>, IBorrowRepository
    {
        public BorrowRepository(BibContext context) : base(context)
        {
        }

        public override IEnumerable<Borrow> Find(Expression<Func<Borrow, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override Borrow Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}