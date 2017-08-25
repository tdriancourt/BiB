using AutoMapper;
using Bib.Domain.Model;
using Bib.Services.ViewModels;

namespace Bib.Services.Profiles
{
    public class MediaTypeProfile : Profile
    {
        public MediaTypeProfile()
        {
            CreateMap<MediaType, MediaTypeViewModel>();
        }
    }
}