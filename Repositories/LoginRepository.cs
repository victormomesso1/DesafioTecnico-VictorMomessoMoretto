using API_RandomUser.Context;
using API_RandomUser.Interfaces;
using API_RandomUser.Models;
using Npgsql;

namespace API_RandomUser.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertLoginAsync(Login login)
        {
            string sql = @"
                INSERT INTO logins (uuid, username, password, salt, md5, sha1, sha256)
                VALUES (@Uuid, @Username, @Password, @Salt, @Md5, @Sha1, @Sha256)
                RETURNING login_id";

            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                command.Parameters.AddWithValue("@Uuid", login.uuid ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Username", login.username ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Password", login.password ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Salt", login.salt ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Md5", login.md5 ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Sha1", login.sha1 ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Sha256", login.sha256 ?? (object)DBNull.Value);

                return (int)await command.ExecuteScalarAsync();
            }
        }

        
    }
}
