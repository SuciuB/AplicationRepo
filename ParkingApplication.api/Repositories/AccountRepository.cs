using System.Data.SqlClient;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;

namespace Repositories;
public class AccountRepository : IQueryRepository<AccountModel>
{
    private readonly DbContext _dbContext;

    public AccountRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

public List<AccountModel> GetAll()
{
    var accounts = new List<AccountModel>();

    using (var connection = _dbContext.GetConnection())
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
