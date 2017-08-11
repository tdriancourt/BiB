using AutoMapper;
using Bib.Domain;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Bib.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Bib.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Contract.Requires(mapper != null);
            Contract.Requires(unitOfWork != null);
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync()
                .ContinueWith(users => _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users.Result));
        }

        public async Task<UserViewModel> GetAsync(int id)
        {
            return await _unitOfWork.UserRepository.GetAsync(id)
                .ContinueWith(user => _mapper.Map<UserViewModel>(user.Result));
        }

        public async Task<bool> Authenticate(LoginViewModel loginViewModel)
        {
            Contract.Requires(loginViewModel != null);
            var user = _mapper.Map<User>(loginViewModel);
            return await _unitOfWork.UserRepository.VerifyAuthentificationAsync(user);
        }
    }
}