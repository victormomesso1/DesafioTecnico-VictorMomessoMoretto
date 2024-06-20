using API_RandomUser.Models;
using API_RandomUser.DTOs;
namespace API_RandomUser.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> FetchUsersFromAPI(string apiUrl);
        Task CreateUserAsync(UserDto user);
        Task<List<ResultDto>> GetAllUsersAsync();
        Task RegisterUserAsync(RegisterToken registerToken);
        Task<RegisterToken> AuthenticateUserAsync(string email, string password);
    }
}
