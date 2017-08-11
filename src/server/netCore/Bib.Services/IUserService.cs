using System.Collections.Generic;
using System.Threading.Tasks;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetAsync(int id);
        Task<bool> Authenticate(LoginViewModel user);
    }
}