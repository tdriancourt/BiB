using AutoMapper;
using Bib.Domain;
using Bib.Domain.Repositories;
using Bib.Services.ViewModels;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Bib.Services
{
    public class AclService : IAclService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public AclService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Contract.Requires(mapper != null);
            Contract.Requires(unitOfWork != null);

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public Task<IEnumerable<AclViewModel>> GetAllAsync()
        {
            return _unitOfWork.AclRepository.GetAllAsync()
                .ContinueWith(acls => _mapper.Map<IEnumerable<AclViewModel>>(acls.Result));
        }

        public Task<AclViewModel> GetAsync(int id)
        {
            return _unitOfWork.AclRepository.GetAsync(id)
                .ContinueWith(acl => _mapper.Map<AclViewModel>(acl.Result));
        }
    }
}