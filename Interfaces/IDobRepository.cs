using API_RandomUser.Models;

namespace API_RandomUser.Interfaces

{
    public interface IDobRepository
    {
        Task<int> InsertDobAsync(Dob dob);
    }
}
