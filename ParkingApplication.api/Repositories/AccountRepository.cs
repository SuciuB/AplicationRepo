using System.Data.SqlClient;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;

namespace Repositories
{
    public class AccountRepository : IQueryRepository<AccountModel>
{
private readonly SqlConnection _connection;

public AccountRepository(SqlConnection connection)
{
    _connection = connection;
}

public List<AccountModel> GetAll()
{
    var accounts = new List<AccountModel>();

    try
    {
        _connection.Open();
        var command = new SqlCommand("SELECT * FROM Account", _connection);

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
    finally
    {
        _connection.Close();
    }

    return accounts;
}
}
}
