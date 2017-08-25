using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bib.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Bib.Domain.Repositories
{
    public interface IBorrowRepository : IAsyncRepository<Borrow>
    {
        Task<IEnumerable<Borrow>> GetOverduesAsync(int borrowingDuration);
        Task<int> GetOverduesCountAsync(int borrowingDuration);
    }
}