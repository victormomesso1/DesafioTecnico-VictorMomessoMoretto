using API_RandomUser.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API_RandomUser.Context
{
    public class AppDbContext : IDisposable
    {
        private readonly NpgsqlConnection _connection;

        public AppDbContext(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }

        public NpgsqlConnection Connection => _connection;

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
