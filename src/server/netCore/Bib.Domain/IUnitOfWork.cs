using System;
using Bib.Domain.Repositories;

namespace Bib.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IAclRepository AclRepository { get; }

        IUserRepository UserRepository { get; }

        void Complete();
    }

}
