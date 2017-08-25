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
    public class UserService : BaseService, IUserService
    {
        public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            return await UnitOfWork.UserRepository.GetAllAsync()
                .ContinueWith(users => Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users.Result));
        }

        public async Task<UserViewModel> GetAsync(int id)
        {
            return await UnitOfWork.UserRepository.GetAsync(id)
                .ContinueWith(user => Mapper.Map<UserViewModel>(user.Result));
        }

        public async Task<bool> Authenticate(LoginViewModel loginViewModel)
        {
            Contract.Requires(loginViewModel != null);
            var user = Mapper.Map<User>(loginViewModel);
            return await UnitOfWork.UserRepository.VerifyAuthentificationAsync(user);
        }
    }
}