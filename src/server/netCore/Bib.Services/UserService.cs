using AutoMapper;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Bib.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Bib.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IUserRepository _repository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            Contract.Requires<ArgumentNullException>(userRepository != null);
            Contract.Requires<ArgumentNullException>(mapper != null);
            _mapper = mapper;
            _repository = userRepository;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var users = _repository.GetAll();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
        }
    }
}