using AutoMapper;
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
        private IUserRepository _repository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            Contract.Requires(mapper != null);
            Contract.Requires(userRepository != null);
            _mapper = mapper;
            _repository = userRepository;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var users = _repository.GetAll();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var task = new Task<IEnumerable<UserViewModel>>(() => GetAll());
            task.Start();

            return await task;
        }
    }
}