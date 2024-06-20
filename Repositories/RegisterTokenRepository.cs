using API_RandomUser.Context;
using API_RandomUser.Interfaces;
using API_RandomUser.Models;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace API_RandomUser.Repositories
{
    public class RegisterTokenRepository : IRegisterTokenRepository
    {
        private readonly AppDbContext _context;

        public RegisterTokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertRegisterTokenAsync(RegisterToken registerToken)
        {
            string sql = @"
                INSERT INTO register_tokens (email, password)
                VALUES (@Email, @Password)";

            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                command.Parameters.AddWithValue("@Email", registerToken.email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Password", registerToken.password ?? (object)DBNull.Value);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<RegisterToken> GetRegisterTokenByEmailAndPasswordAsync(string email, string password)
        {
            string sql = "SELECT email, password FROM register_tokens WHERE email = @Email AND password = @Password";
            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                command.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Password", password ?? (object)DBNull.Value);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new RegisterToken
                        {
                            email = reader.GetString(0),
                            password = reader.GetString(1)
                        };
                    }
                    return null;
                }
            }
        }
    }
}