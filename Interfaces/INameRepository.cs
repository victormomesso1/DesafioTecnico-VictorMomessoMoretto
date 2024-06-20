using API_RandomUser.Models;

namespace API_RandomUser.Interfaces
{
    public interface INameRepository
    {
        Task<int> InsertNameAsync(Name name);
    }
}
