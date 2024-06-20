using API_RandomUser.Context;
using API_RandomUser.Interfaces;
using API_RandomUser.Models;
using Npgsql;

namespace API_RandomUser.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly AppDbContext _context;

        public PictureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertPictureAsync(Picture picture)
        {
            string sql = @"
                INSERT INTO pictures (large, medium, thumbnail)
                VALUES (@Large, @Medium, @Thumbnail)
                RETURNING picture_id";

            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                command.Parameters.AddWithValue("@Large", picture.large ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Medium", picture.medium ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Thumbnail", picture.thumbnail ?? (object)DBNull.Value);

                return (int)await command.ExecuteScalarAsync();
            }
        }

        
    }
}