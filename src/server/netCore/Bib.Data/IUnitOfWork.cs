using System;
using Bib.Domain.Repository;

namespace Bib.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IAclRepository AclRepository { get; }

        IUserRepository UserRepository { get; }

        void Complete();
    }

}
