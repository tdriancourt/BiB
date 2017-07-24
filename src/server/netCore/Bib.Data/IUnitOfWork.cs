using System;
using Bib.Domain.Repositories;

namespace Bib.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IAclRepository AclRepository { get; }

        IUserRepository UserRepository { get; }

        void Complete();
    }

}
