using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class ReaderRepository : BaseAsyncRepository<Reader>, IReaderRepository
    {
        public ReaderRepository(BibContext context) : base(context)
        {
        }
    }
}