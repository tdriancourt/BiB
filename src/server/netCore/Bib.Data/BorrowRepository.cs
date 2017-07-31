using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class BorrowRepository : BaseRepository<Borrow>, IBorrowRepository
    {
        public BorrowRepository(BibContext context) : base(context)
        {
        }
    }
}