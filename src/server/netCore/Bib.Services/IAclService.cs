using Bib.Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bib.Services
{
    public interface IAclService
    {
        Task<IEnumerable<AclViewModel>> GetAllAsync();
        Task<AclViewModel> GetAsync(int id);
    }
}