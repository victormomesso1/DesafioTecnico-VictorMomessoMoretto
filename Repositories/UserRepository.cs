using API_RandomUser.Context;
using API_RandomUser.Interfaces;
using API_RandomUser.Models;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_RandomUser.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertUserAsync(Result user)
        {
            string sql = @"
                INSERT INTO users 
                (gender, email, phone, cell, nat, name_id, location_id, login_id, dob_id, registered_id, id_id, picture_id)
                VALUES
                (@Gender, @Email, @Phone, @Cell, @Nat, @NameId, @LocationId, @LoginId, @DobId, @RegisteredId, @IdId, @PictureId)
                RETURNING user_id";

            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                command.Parameters.AddWithValue("@Gender", user.gender ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", user.email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Phone", user.phone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Cell", user.cell ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Nat", user.nat ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NameId", user.nameId);
                command.Parameters.AddWithValue("@LocationId", user.locationId);
                command.Parameters.AddWithValue("@LoginId", user.loginId);
                command.Parameters.AddWithValue("@DobId", user.dobId);
                command.Parameters.AddWithValue("@RegisteredId", user.registeredId);
                command.Parameters.AddWithValue("@IdId", user.idId);
                command.Parameters.AddWithValue("@PictureId", user.pictureId);

                return (int)await command.ExecuteScalarAsync();
            }
        } 
        public async Task<List<Result>> GetAllUsersAsync()
        {
            var users = new List<Result>();
            string sql = @"
                SELECT user_id, gender, email, phone, cell, nat, name_id, location_id, login_id, dob_id, registered_id, id_id, picture_id
                FROM users";

            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var user = new Result
                        {
                            user_id = reader.GetInt32(0),
                            gender = reader.IsDBNull(1) ? null : reader.GetString(1),
                            email = reader.IsDBNull(2) ? null : reader.GetString(2),
                            phone = reader.IsDBNull(3) ? null : reader.GetString(3),
                            cell = reader.IsDBNull(4) ? null : reader.GetString(4),
                            nat = reader.IsDBNull(5) ? null : reader.GetString(5),
                            nameId = reader.GetInt32(6),
                            locationId = reader.GetInt32(7),
                            loginId = reader.GetInt32(8),
                            dobId = reader.GetInt32(9),
                            registeredId = reader.GetInt32(10),
                            idId = reader.GetInt32(11),
                            pictureId = reader.GetInt32(12)
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}
