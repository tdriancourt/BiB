using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class ReaderRepository : BaseRepository<Reader>, IReaderRepository
    {
        public ReaderRepository(BibContext context) : base(context)
        {
        }

        public override IEnumerable<Reader> Find(Expression<Func<Reader, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override Reader Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}