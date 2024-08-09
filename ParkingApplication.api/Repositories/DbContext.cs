using System.Data.SqlClient;
using ParkingApplication.Api.Interfaces;

public class DbContext : IDbContext
{
    private readonly string _connectionString;

    public DbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}