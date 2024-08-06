using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Api.Interfaces
{
    public interface IQueryRepository<T>
    {
        List<T> GetAll();
    }
}