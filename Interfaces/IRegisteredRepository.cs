using API_RandomUser.Models;

namespace API_RandomUser.Interfaces
{
    public interface IRegisteredRepository
    {
        Task<int> InsertRegisteredAsync(Registered registered);
    }
}
