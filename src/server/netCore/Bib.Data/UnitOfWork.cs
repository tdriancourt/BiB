using System;
using Bib.Domain.Model;
using Bib.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private BibContext _context;
        
        public UnitOfWork(DbContext context, IAclRepository aclRepository, IUserRepository userRepository)
        {
            AclRepository = aclRepository;
            UserRepository = userRepository;
            _context = (BibContext)context;
        }
        
        public IAclRepository AclRepository { get; private set; }
        public IBorrowRepository BorrowRepository { get; set; }
        public IMediaTypeRepository MediaTypeRepository { get; set; }
        public IMediumRepository MediumRepository { get; set; }
        public IReaderRepository ReaderRepository { get; set; }
        public IUserGroupRepository UserGroupRepository { get; set; }
        public IUserSettingsRepository UserSettingsRepository { get; set; }
        public IUserRepository UserRepository {get; private set;}

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}