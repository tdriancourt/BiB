using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using AutoMapper;
using Bib.Domain;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public class UserGroupService : IUserGroupService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        
        
        public UserGroupService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Contract.Requires(mapper != null);
            Contract.Requires(unitOfWork != null);
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserGroupViewModel>> GetAllAsync()
        {
             return await _unitOfWork.UserGroupRepository.GetAllAsync()
                .ContinueWith(userGroups => _mapper.Map<IEnumerable<UserGroupViewModel>>(userGroups.Result));
        }

        public async Task<UserGroupViewModel> GetAsync(int id)
        {
            return await _unitOfWork.UserGroupRepository.GetAsync(id)
                .ContinueWith(userGroup => _mapper.Map<UserGroupViewModel>(userGroup.Result));
        }
    }
}