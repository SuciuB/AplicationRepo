using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Api.Repositories;
public class ParkingRepository : IQueryRepository<ParkingModel>, ICommandRepository<ParkingModel>
{
private readonly DbContext _dbContext;

    public ParkingRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

public List<ParkingModel> GetAll()
{

    var cars = new List<ParkingModel>();
    using (var connection = _dbContext.GetConnection())
{
    connection.Open();
    var command = new SqlCommand("SELECT * FROM ParkedCar", connection);

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
    return cars;
}

public ParkingModel GetByCarNumber(string carNumber)
{
    var carId = GetAll();
    return carId.Find(car => car.CarNumber == carNumber);
}

public void Create(ParkingModel parkingModel)
{
        using (var connection = _dbContext.GetConnection())
    {
        connection.Open();
        var command = new SqlCommand("INSERT INTO ParkedCar (Id, CarNumber, UserId) VALUES (@Id, @CarNumber, @UserId)", connection);
        command.Parameters.AddWithValue("@Id", parkingModel.Id);
        command.Parameters.AddWithValue("@CarNumber", parkingModel.CarNumber);
        command.Parameters.AddWithValue("@UserId", parkingModel.UserId);
        command.ExecuteNonQuery();
    }
}

public void Delete(ParkingModel parkingModel)
{
   using (var connection = _dbContext.GetConnection())
    {
        connection.Open();
        var command = new SqlCommand("DELETE FROM ParkedCar WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", parkingModel.Id);
        command.ExecuteNonQuery();
    }
}

}