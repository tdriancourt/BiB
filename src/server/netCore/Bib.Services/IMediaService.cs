using System.Threading.Tasks;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public interface IMediaService
    {
         Task<MediaViewModel> GetAllAsync(int id);
    }
}