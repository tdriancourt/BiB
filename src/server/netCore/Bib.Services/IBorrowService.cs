using Bib.Services.ViewModels;
using System.Threading.Tasks;

namespace Bib.Services
{
    public interface IBorrowService
    {
         Task<BorrowViewModel> GetAllAsync();
    }
}