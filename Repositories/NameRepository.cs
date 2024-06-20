using API_RandomUser.Context;
using API_RandomUser.Interfaces;
using API_RandomUser.Models;
using Npgsql;

namespace API_RandomUser.Repositories
{
    public class NameRepository : INameRepository
    {
        private readonly AppDbContext _context;

        public NameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertNameAsync(Name name)
        {
            string sql = @"
                INSERT INTO names (title, first, last)
                VALUES (@Title, @First, @Last)
                RETURNING name_id";

            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                command.Parameters.AddWithValue("@Title", name.title ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@First", name.first ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Last", name.last ?? (object)DBNull.Value);

                return (int)await command.ExecuteScalarAsync();
            }
        }

       
    }
}