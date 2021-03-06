using System;
using Bib.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Bib.Domain.Repositories
{
    public interface IMediaTypeRepository : IAsyncRepository<MediaType>
    {
    }
}