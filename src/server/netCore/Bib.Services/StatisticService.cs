using AutoMapper;
using Bib.Domain;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public class StatisticService : BaseService, IStatisticService
    {
        public StatisticService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async StatisticalViewModel GetAsync()
        {
            return new StatisticalViewModel()
            {
                BorrowsCount = await UnitOfWork.BorrowRepository.CountAsync(),
                MediaCount = await UnitOfWork.MediumRepository.CountAsync(),
                OverduesCount = await UnitOfWork.MediumRepository.GetOverduesCountAsync(),
                ReadersCount = await UnitOfWork.ReaderRepository.CountAsync(),
                UsersCount = await UnitOfWork.UserRepository.CountAsync()
            };
        }
    }
}