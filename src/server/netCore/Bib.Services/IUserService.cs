using System.Collections.Generic;
using Bib.Services.ViewModels;

namespace Bib.Services
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAll();
    }
}