using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bib.Data
{
    public class UserRepository : BaseAsyncRepository<User>, IUserRepository
    {
        public UserRepository(BibContext context) : base(context)
        {
        }

        public Task<bool> VerifyAuthentificationAsync(User user)
        {
            return Context.User.AnyAsync(u => u.AccountName == user.AccountName && u.Password == user.Password);
        }
    }
}