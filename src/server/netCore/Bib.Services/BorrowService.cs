using System.Threading.Tasks;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public class BorrowService : IBorrowService
    {
        public Task<BorrowViewModel> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}