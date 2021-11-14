using AutoMapper;
using User.API.Models.Beers;
using User.BusinessLogic.Dtos.Beer;

namespace User.API.MapperProfiles
{
    public class BeersProfile : Profile
    {
        public BeersProfile()
        {
            CreateMap<BeerDto, BeerModel>(MemberList.None);
        }
    }
}