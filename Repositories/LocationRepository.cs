using API_RandomUser.Context;
using API_RandomUser.Interfaces;
using API_RandomUser.Models;
using Npgsql;

namespace API_RandomUser.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertLocationAsync(Location location)
        {
            string sql = @"
                INSERT INTO locations (street_number, street_name, city, state, country, postcode, coordinates_latitude, coordinates_longitude, timezone_offset, timezone_description)
                VALUES (@StreetNumber, @StreetName, @City, @State, @Country, @Postcode, @Latitude, @Longitude, @Offset, @Description)
                RETURNING location_id";

            using (var command = new NpgsqlCommand(sql, _context.Connection))
            {
                command.Parameters.AddWithValue("@StreetNumber", location.street.number);
                command.Parameters.AddWithValue("@StreetName", location.street.name ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@City", location.city ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@State", location.state ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Country", location.country ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Postcode", location.postcode);
                command.Parameters.AddWithValue("@Latitude", location.coordinates.latitude ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Longitude", location.coordinates.longitude ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Offset", location.timezone.offset ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Description", location.timezone.description ?? (object)DBNull.Value);

                return (int)await command.ExecuteScalarAsync();
            }
        }

      
    }
}
