using System;
using Bib.Domain.Model;

namespace Bib.Domain.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}