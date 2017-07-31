using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bib.Data;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bib.Data
{
    public class UserSettingsRepository : BaseRepository<UserSettings>, IUserSettingsRepository
    {
        public UserSettingsRepository(BibContext context) : base(context)
        {
        }
    }
}