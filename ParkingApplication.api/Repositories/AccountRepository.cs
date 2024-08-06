using System.Data.SqlClient;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;
using Microsoft.Extensions.Options;
using ParkingApplication.Api.Configuration;

namespace Repositories
{
public class AccountRepository : IQueryRepository<AccountModel>
{
private readonly string _connectionString;

public AccountRepository(IOptions<ConnectionStrings> connectionStrings)
{
    _connectionString = connectionStrings.Value.DefaultConnection;
}

public List<AccountModel> GetAll()
{
var accounts = new List<AccountModel>();

using (var connection = new SqlConnection(_connectionString))
{
    connection.Open();
    var command = new SqlCommand("SELECT * FROM Account", connection);

    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            int accountId = (int)reader["AccountId"];
            double amount = Convert.ToDouble(reader["Amount"]);
            int userId = (int)reader["UserId"];

            accounts.Add(new AccountModel(accountId, amount, userId));
        }
    }
}

    return accounts;
}
}
}
