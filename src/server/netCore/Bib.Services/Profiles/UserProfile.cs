using AutoMapper;
using Bib.Domain.Model;
using Bib.Services.ViewModels;

namespace Bib.Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}