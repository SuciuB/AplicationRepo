// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Xunit;
// using ParkingApplication;

// namespace ParkingApplication.Tests
// {
//     public class UserTests
//     {
//         [Fact]
//         public void FindingCarId_FindingIds_SameId()
//         {
//             UserService userService = new UserService();
//             var addToList = new UserModel(2, "Suciu", "Andrei");
//             userService.ListOfUsers.Add(addToList);

//             var result = userService.FindingCarId(2);


//             Assert.True(result);
//         }

//         [Fact]
//         public void FindingCarId_FindingIds_DifferentId()
//         {
//             UserService userService = new UserService();
//             var addToList = new UserModel(2, "Suciu", "Andrei");
//             userService.ListOfUsers.Add(addToList);

//             var result = userService.FindingCarId(3);


//             Assert.True(result);
//         }
//     }
// }