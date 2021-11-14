using AutoMapper;
using User.API.Models.Users;
using User.BusinessLogic.Dtos.User;

namespace User.API.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpModel, SignUpDto>(MemberList.None);

            CreateMap<UserBeersDto, UserBeersModel>(MemberList.None);
        }
    }
}