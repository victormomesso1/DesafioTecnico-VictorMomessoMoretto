using API_RandomUser.Models;

namespace API_RandomUser.Interfaces
{
    public interface IUserRepository
    {
        Task<int> InsertUserAsync(Result user);
        Task<List<Result>> GetAllUsersAsync();
    }
}
