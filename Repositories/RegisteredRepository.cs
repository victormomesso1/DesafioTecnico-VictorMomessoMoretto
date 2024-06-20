using API_RandomUser.Context;
using API_RandomUser.Interfaces;
using API_RandomUser.Models;
using Npgsql;

namespace API_RandomUser.Repositories
{
    public class RegisteredRepository : IRegisteredRepository
    {
        private readonly AppDbContext _context;

        public RegisteredRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertRegisteredAsync(Registered registered)
        {
            string sql = @"
                INSERT INTO registereds (date, age)
                VALUES (@Date, @Age)
                RETURNING registered_id";

            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                command.Parameters.AddWithValue("@Date", registered.date);
                command.Parameters.AddWithValue("@Age", registered.age);

                return (int)await command.ExecuteScalarAsync();
            }
        }

        
    }
}