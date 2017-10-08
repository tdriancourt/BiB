using System;
using System.Threading.Tasks;
using Bib.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Bib.Domain.Repositories
{
    public interface IMediumRepository : IAsyncRepository<Medium>
    {
        Task<int> GetOverduesCountAsync(int loanDuration);
    }
}