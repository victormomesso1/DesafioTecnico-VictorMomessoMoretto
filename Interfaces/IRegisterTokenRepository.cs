using API_RandomUser.Models;
using System.Threading.Tasks;
using API_RandomUser.DTOs;
using API_RandomUser.Repositories;
namespace API_RandomUser.Interfaces
{
    public interface IRegisterTokenRepository
    {
        Task InsertRegisterTokenAsync(RegisterToken registerToken);
        Task<RegisterToken> GetRegisterTokenByEmailAndPasswordAsync(string email, string password);
    }
}
