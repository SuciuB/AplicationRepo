using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ParkingApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()

            {
                return await Task.FromResult(Ok("Merge"));
            }

        // [HttpPost("park")]
        // public IActionResult AddToParking(int CarId, string CarNumber)
        // {
        //     try
        //     {
        //         _parkingService.AddToParking(CarId, CarNumber);
        //         return Ok("Car added to parking successfully.");
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, $"Internal server error: {ex.Message}");
        //     }
        // }

        // [HttpDelete("exit")]
        // public IActionResult ExitParking(string CarNumber)
        // {
        //     try
        //     {
        //         bool exited = _parkingService.ExitParking(CarNumber);
        //         if (exited)
        //         {
        //             return Ok("Car exited from parking successfully.");
        //         }
        //         else
        //         {
        //             return NotFound("Car not found in parking.");
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, $"Internal server error: {ex.Message}");
        //     }
        // }
    }
}