using AutoMapper;
using Bib.Domain.Model;
using Bib.Services.ViewModels;

namespace Bib.Services.Profiles
{
    public class AclProfile : Profile
    {
        public AclProfile()
        {
            CreateMap<Acl, AclViewModel>();
        }
    }
}