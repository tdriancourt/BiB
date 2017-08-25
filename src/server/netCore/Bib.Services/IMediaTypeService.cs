using System.Collections.Generic;
using System.Threading.Tasks;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public interface IMediaTypeService
    {
         Task<IEnumerable<MediaTypeViewModel>> GetAllAsync();
         Task<MediaTypeViewModel> GetAsync(int id);
    }
}