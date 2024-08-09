using System.Data.SqlClient;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;
using System.Collections.Generic;

namespace Repositories;
    public class AccountRepository : IQueryRepository<AccountModel>
{
    private readonly IDbContext _dbContext;

    public AccountRepository(IDbContext dbContext)
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
