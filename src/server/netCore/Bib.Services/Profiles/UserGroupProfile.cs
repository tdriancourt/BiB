using AutoMapper;
using Bib.Domain.Model;
using Bib.Services.ViewModels;

namespace Bib.Services.Profiles
{
    public class UserGroupProfile : Profile
    {
        public UserGroupProfile()
        {
            CreateMap<UserGroup, UserGroupViewModel>();
        }
    }
}