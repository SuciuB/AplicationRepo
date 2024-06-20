using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public class UserModel
    {
        
        

        public UserModel(int userId, string firstName, string lastName)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
    }


        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }

}