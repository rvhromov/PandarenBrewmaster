using AutoMapper;
using Beer.API.Dtos;
using Beer.API.Dtos.Beer;

namespace Beer.API.MapperProfiles
{
    public class BeerProfile : Profile
    {
        public BeerProfile()
        {
            CreateMap<Entities.Beer, BeerDto>(MemberList.None);

            CreateMap<CreateBeerDto, Entities.Beer>(MemberList.None);
        }
    }
}