using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.UserSecrets;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Services;
public class UserService
{
    public List<UserModel> ListOfUsers = new List<UserModel> {new UserModel(1, "Suciu", "Bogdan"), new UserModel(2, "Ionescu", "Andrei")}; 
}