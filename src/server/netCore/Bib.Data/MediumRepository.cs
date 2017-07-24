using System;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class MediumRepository : BaseRepository<Medium>, IMediumRepository
    {
        public MediumRepository(DbContext context) : base(context)
        {
        }
    }
}