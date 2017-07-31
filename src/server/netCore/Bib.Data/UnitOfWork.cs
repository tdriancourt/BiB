using System;
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
        
        public UnitOfWork(BibContext context, IAclRepository aclRepository, IUserRepository userRepository)
        {
            AclRepository = aclRepository;
            UserRepository = userRepository;
            _context = (BibContext)context;
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