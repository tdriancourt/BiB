using System;
using System.Diagnostics.Contracts;
using Bib.Domain;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bib.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private BibContext _context;
        private IDbContextTransaction _transaction;
        
        public UnitOfWork(BibContext context, 
        IAclRepository aclRepository, 
        IBorrowRepository borrowRepository,
        IMediaTypeRepository mediaTypeRepository,
        IMediumRepository mediumRepository,
        IUserRepository userRepository,
        IUserGroupRepository userGroupRepository)
        {
            Contract.Requires(context != null);
            Contract.Requires(aclRepository != null);
            Contract.Requires(borrowRepository != null);
            Contract.Requires(mediaTypeRepository != null);
            Contract.Requires(mediumRepository != null);
            Contract.Requires(userRepository != null);
            Contract.Requires(userGroupRepository != null);
            _context = (BibContext)context;
            AclRepository = aclRepository;
            BorrowRepository = borrowRepository;
            MediaTypeRepository = mediaTypeRepository;
            MediumRepository = mediumRepository;
            UserRepository = userRepository;
            UserGroupRepository = userGroupRepository;
            _transaction = _context.Database.BeginTransaction();                       
        }
        
        public IAclRepository AclRepository { get; private set; }
        public IBorrowRepository BorrowRepository { get; private set; }
        public IMediaTypeRepository MediaTypeRepository { get; private set; }
        public IMediumRepository MediumRepository { get; private set; }
        public IReaderRepository ReaderRepository { get; private set; }
        public IUserGroupRepository UserGroupRepository { get; private set; }
        public IUserSettingsRepository UserSettingsRepository { get; private set; }
        public IUserRepository UserRepository {get; private set;}

        public void Complete()
        {
            _context.SaveChanges();
            _transaction.Commit();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}