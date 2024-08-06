using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ParkingApplication.Api.Models;
using ParkingApplication.Services;

public class DbContext
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
