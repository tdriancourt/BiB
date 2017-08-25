using AutoMapper;
using Bib.Domain.Model;
using Bib.Services.ViewModels;

namespace Bib.Services.Profiles
{
    public class BorrowProfile : Profile
    {
        public BorrowProfile()
        {
            CreateMap<Borrow, BorrowViewModel>();
        }
    }
}