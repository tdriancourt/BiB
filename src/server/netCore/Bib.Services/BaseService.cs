using System.Diagnostics.Contracts;
using AutoMapper;
using Bib.Domain;

namespace Bib.Services
{
    public class BaseService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        protected IMapper Mapper => _mapper;

        protected IUnitOfWork UnitOfWork => _unitOfWork;

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Contract.Requires(mapper != null);
            Contract.Requires(unitOfWork != null);
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}