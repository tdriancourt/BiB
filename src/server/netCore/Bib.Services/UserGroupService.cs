using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using AutoMapper;
using Bib.Domain;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public class UserGroupService : BaseService, IUserGroupService
    {
        public UserGroupService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<UserGroupViewModel>> GetAllAsync()
        {
             return await UnitOfWork.UserGroupRepository.GetAllAsync()
                .ContinueWith(userGroups => Mapper.Map<IEnumerable<UserGroupViewModel>>(userGroups.Result));
        }

        public async Task<UserGroupViewModel> GetAsync(int id)
        {
            return await UnitOfWork.UserGroupRepository.GetAsync(id)
                .ContinueWith(userGroup => Mapper.Map<UserGroupViewModel>(userGroup.Result));
        }
    }
}