using System;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class AclRepository : BaseRepository<Acl>, IAclRepository
    {
        public AclRepository(DbContext context) : base(context)
        {
        }
    }
}