using Bib.Domain.Model;
using System;
using System.Threading.Tasks;

namespace Bib.Domain.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<bool> VerifyAuthentificationAsync(User user);
    }
}