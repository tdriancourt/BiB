using System;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class MediaTypeRepository : BaseRepository<MediaType>, IMediaTypeRepository 
    {
        public MediaTypeRepository(DbContext context) : base(context)
        {
        }
    }
}