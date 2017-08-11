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
            CreateMap<LoginViewModel, User>()
                .ForMember(d => d.AccountName, opt => opt.MapFrom(s => s.AccountName))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(d => d.Acl, opt => opt.Ignore())
                .ForMember(d => d.AclId, opt => opt.Ignore())
                .ForMember(d => d.FirstName, opt => opt.Ignore())
                .ForMember(d => d.Group, opt => opt.Ignore())
                .ForMember(d => d.GroupId, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.IsActive, opt => opt.Ignore())
                .ForMember(d => d.LastName, opt => opt.Ignore())
                .ForMember(d => d.UserSettings, opt => opt.Ignore());
            CreateMap<UserViewModel, User>();
        }
    }
}