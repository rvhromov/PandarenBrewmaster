using AutoMapper;
using User.BusinessLogic.Dtos.Beer;
using User.Domain.Entities;

namespace User.BusinessLogic.MapperProfiles
{
    public class BeerProfile : Profile
    {
        public BeerProfile()
        {
            CreateMap<Rate, BeerDto>(MemberList.None)
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Beer.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Beer.Name));
        }
    }
}