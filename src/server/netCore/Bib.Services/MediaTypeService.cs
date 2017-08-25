using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bib.Domain;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public class MediaTypeService : BaseService, IMediaTypeService
    {
        public MediaTypeService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<IEnumerable<MediaTypeViewModel>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<MediaTypeViewModel> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}