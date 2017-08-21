using System.Collections.Generic;
using System.Threading.Tasks;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public interface IUserGroupService
    {
         Task<IEnumerable<UserGroupViewModel>> GetAllAsync();
         Task<UserGroupViewModel> GetAsync(int id);
    }
}