using System;
using System.Diagnostics.Contracts;
using Bib.Domain.Repositories;

namespace Bib.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            Contract.Requires<ArgumentNullException>(userRepository != null);
            
            _repository = userRepository;
        }
    }
}