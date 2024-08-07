using ParkingApplication.Api.Configuration;
using System.Data.SqlClient;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Api.Repositories;
    public class ParkingRepository : IQueryRepository<ParkingModel>, ICommandRepository<ParkingModel>
{
    private readonly SqlConnection _connection;

    public ParkingRepository(SqlConnection connection)
    {
        _connection = connection;
    }

    public List<ParkingModel> GetAll()
    {
        var cars = new List<ParkingModel>();

        try
        {
            _connection.Open();
            var command = new SqlCommand("SELECT * FROM ParkedCar", _connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string carNumber = reader["CarNumber"].ToString();
                    var userId = reader["UserId"];

                    cars.Add(new ParkingModel(id, carNumber, (int)userId));
                }
            }
        }
        finally
        {
            _connection.Close(); 
        }

        return cars;
    }

    public ParkingModel GetByCarNumber(string carNumber)
    {
        var carId = GetAll();
        return carId.Find(car => car.CarNumber == carNumber);
    }

    public void Create(ParkingModel parkingModel)
    {
        try
        {
            _connection.Open();
            var command = new SqlCommand("INSERT INTO ParkedCar (Id, CarNumber, UserId) VALUES (@Id, @CarNumber, @UserId)", _connection);
            command.Parameters.AddWithValue("@Id", parkingModel.Id);
            command.Parameters.AddWithValue("@CarNumber", parkingModel.CarNumber);
            command.Parameters.AddWithValue("@UserId", parkingModel.UserId);
            command.ExecuteNonQuery();
        }
        finally
        {
            _connection.Close();
        }
    }

    public void Delete(ParkingModel parkingModel)
    {
        try
        {
            _connection.Open();
            var command = new SqlCommand("DELETE FROM ParkedCar WHERE Id = @Id", _connection);
            command.Parameters.AddWithValue("@Id", parkingModel.Id);
            command.ExecuteNonQuery();
        }
        finally
        {
            _connection.Close();
        }
    }
}
