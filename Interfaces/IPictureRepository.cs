using API_RandomUser.Models;

namespace API_RandomUser.Interfaces
{
    public interface IPictureRepository
    {
        Task<int> InsertPictureAsync(Picture picture);
    }
}
