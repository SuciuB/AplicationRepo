using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Api.Interfaces
{
    public interface ICommandRepository
    {
        void Create(ParkingModel parkingModel);
        void Delete(int id);
    }
}