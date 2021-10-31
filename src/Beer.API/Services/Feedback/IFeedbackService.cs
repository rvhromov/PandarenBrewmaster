using System.Threading.Tasks;
using Beer.API.Dtos.Feedback;

namespace Beer.API.Services.Feedback
{
    public interface IFeedbackService
    {
        Task CreateAsync(string beerId, CreateFeedbackDto createDto);
    }
}