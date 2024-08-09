using System.Data.SqlClient;

namespace ParkingApplication.Api.Interfaces
{
    public interface IDbContext
    {
        SqlConnection GetConnection(); 
    }
}