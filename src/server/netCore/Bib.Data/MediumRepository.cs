using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class MediumRepository : BaseAsyncRepository<Medium>, IMediumRepository
    {
        public MediumRepository(BibContext context) : base(context)
        {
        }
    }
}