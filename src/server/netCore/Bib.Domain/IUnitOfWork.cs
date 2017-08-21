using System;
using Bib.Domain.Repositories;

namespace Bib.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IAclRepository AclRepository { get; }
        IBorrowRepository BorrowRepository { get; }
        IMediaTypeRepository MediaTypeRepository { get; }
        IMediumRepository MediumRepository { get; }
        IReaderRepository ReaderRepository { get; }
        IUserGroupRepository UserGroupRepository { get; }
        IUserSettingsRepository UserSettingsRepository { get; }
        IUserRepository UserRepository { get; }

        void Complete();
    }

}
