using API_RandomUser.Models;

namespace API_RandomUser.Interfaces
{
    public interface ILoginRepository
    {
        Task<int> InsertLoginAsync(Login login);
    }
}
