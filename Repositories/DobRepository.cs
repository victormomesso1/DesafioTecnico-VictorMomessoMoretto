using API_RandomUser.Context;
using API_RandomUser.Interfaces;
using API_RandomUser.Models;
using Npgsql;

namespace API_RandomUser.Repositories
{
    public class DobRepository : IDobRepository
    {
        private readonly AppDbContext _context;

        public DobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertDobAsync(Dob dob)
        {
            string sql = @"
                INSERT INTO dobs (date, age)
                VALUES (@Date, @Age)
                RETURNING dob_id";

            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                command.Parameters.AddWithValue("@Date", dob.date);
                command.Parameters.AddWithValue("@Age", dob.age);

                return (int)await command.ExecuteScalarAsync();
            }
        }

       
    }
}