using AutoMapper;
using Beer.API.Dtos.Feedback;
using Beer.API.Entities;

namespace Beer.API.MapperProfiles
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<CreateFeedbackDto, Feedback>(MemberList.None);
        }
    }
}