using API_RandomUser.Context;
using API_RandomUser.Interfaces;
using API_RandomUser.Models;
using Npgsql;

namespace API_RandomUser.Repositories
{
    public class IdRepository : IIDRepository
    {
        private readonly AppDbContext _context;

        public IdRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertIdAsync(Id id)
        {
            string sql = @"
                INSERT INTO ids (name, value)
                VALUES (@Name, @Value)
                RETURNING id_id";

            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                command.Parameters.AddWithValue("@Name", id.name ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Value", id.value ?? (object)DBNull.Value);

                return (int)await command.ExecuteScalarAsync();
            }
        }

       
    }
}
