using API_RandomUser.Models;

namespace API_RandomUser.Interfaces
{
    public interface IIDRepository
    {
        Task<int> InsertIdAsync(Id id);
    }
}
