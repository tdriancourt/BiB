using System.Collections.Generic;
using System.Threading.Tasks;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAll();
        Task<IEnumerable<UserViewModel>> GetAllAsync();
    }
}