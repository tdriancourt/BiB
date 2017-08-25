using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using AutoMapper;
using Bib.Domain;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public class BorrowService : BaseService, IBorrowService
    {
        public BorrowService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {}
        
        public async Task<BorrowViewModel> GetAllAsync()
        {
            return await UnitOfWork.BorrowRepository.GetAllAsync()
                .ContinueWith(borrows => Mapper.Map<BorrowViewModel>(borrows.Result));
        }

        public async Task<BorrowViewModel> GetAsync(int id)
        {
            return await UnitOfWork.BorrowRepository.GetAsync(id)
                .ContinueWith(borrow => Mapper.Map<BorrowViewModel>(borrow.Result));
        }
    }
}