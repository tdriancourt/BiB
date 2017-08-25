using System.Collections.Generic;
using System.Threading.Tasks;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public interface IMediumService
    {
        Task<IEnumerable<MediumViewModel>> GetAllAsync();
        Task<MediumViewModel> GetAsync(int id);
    }
}