using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bib.Domain;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public class MediumService : BaseService, IMediumService
    {
        public MediumService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<IEnumerable<MediumViewModel>> GetAllAsync()
        {
            return UnitOfWork.MediumRepository.GetAllAsync()
                .ContinueWith(mediums => Mapper.Map<IEnumerable<MediumViewModel>>(mediums.Result));
        }

        public Task<MediumViewModel> GetAsync(int id)
        {
            return UnitOfWork.MediumRepository.GetAsync(id)
                .ContinueWith(mediums => Mapper.Map<MediumViewModel>(mediums.Result));
        }
    }
}