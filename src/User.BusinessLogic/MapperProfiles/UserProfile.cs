using AutoMapper;
using User.BusinessLogic.Dtos.User;

namespace User.BusinessLogic.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpDto, Domain.Entities.User>(MemberList.None);

            CreateMap<Domain.Entities.User, UserBeersDto>(MemberList.None)
                .ForMember(dst => dst.Beers, opt => opt.MapFrom(src => src.BeerRates));
        }
    }
}