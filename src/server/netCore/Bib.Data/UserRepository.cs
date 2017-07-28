using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BibContext context) : base(context)
        {
        }

        public override IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override User Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}