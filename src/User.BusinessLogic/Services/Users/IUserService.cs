using System.Threading.Tasks;
using User.BusinessLogic.Dtos.User;

namespace User.BusinessLogic.Services.Users
{
    public interface IUserService
    {
        Task<int> SignUpAsync(SignUpDto signUpModel);

        Task<UserBeersDto> GetUserBeersAsync(int userId);
    }
}