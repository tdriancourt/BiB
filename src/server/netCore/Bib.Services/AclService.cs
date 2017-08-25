using AutoMapper;
using Bib.Domain;
using Bib.Domain.Repositories;
using Bib.Services.ViewModels;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Bib.Services
{
    public class AclService : BaseService, IAclService
    {
        public AclService(IMapper mapper, IUnitOfWork unitOfWork): base(mapper, unitOfWork)
        {
        }
        
        public Task<IEnumerable<AclViewModel>> GetAllAsync()
        {
            return UnitOfWork.AclRepository.GetAllAsync()
                .ContinueWith(acls => Mapper.Map<IEnumerable<AclViewModel>>(acls.Result));
        }

        public Task<AclViewModel> GetAsync(int id)
        {
            return UnitOfWork.AclRepository.GetAsync(id)
                .ContinueWith(acl => Mapper.Map<AclViewModel>(acl.Result));
        }
    }
}