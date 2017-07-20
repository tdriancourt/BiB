using System;
using Bib.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Bib.Domain.Repository
{
    public interface IMediumRepository : IRepository<Medium>
    {
    }
}