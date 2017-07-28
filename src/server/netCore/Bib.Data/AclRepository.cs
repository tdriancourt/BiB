using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class AclRepository : BaseRepository<Acl>, IAclRepository
    {
        public AclRepository(BibContext context) : base(context)
        {
        }

        public override IEnumerable<Acl> Find(Expression<Func<Acl, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override Acl Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}