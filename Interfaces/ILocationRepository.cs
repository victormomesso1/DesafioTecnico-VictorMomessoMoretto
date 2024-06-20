using API_RandomUser.Models;

namespace API_RandomUser.Interfaces
{
    public interface ILocationRepository
    {
        Task<int> InsertLocationAsync(Location location);
    }
}
