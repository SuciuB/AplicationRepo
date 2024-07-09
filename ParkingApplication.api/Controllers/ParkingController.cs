using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ParkingApplication;


[ApiController]
[Route("api/[controller]")]
public class ParkingController : ControllerBase
{
    private readonly IParkingService _parkingService;

    public ParkingController(IParkingService parkingService)
    {
        _parkingService = parkingService;
    }

    // Endpoint to retrieve list of parked cars
    [HttpGet]
    public ActionResult<List<ParkingModel>> GetListOfParkedCars()
    {
        return Ok(_parkingService.ListOfParkedCar);
    }

    // Endpoint to add a car to parking
    [HttpPost("add-to-parking")]
    public IActionResult AddToParking([FromBody] ParkingModel car)
    {
        try
        {
            _parkingService.AddToParking(car.CarId, car.CarNumber);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint to exit from parking
    [HttpDelete("exit-parking/{carNumber}")]
    public IActionResult ExitParking(string carNumber)
    {
        try
        {
            bool exited = _parkingService.ExitParking(carNumber);
            if (exited)
                return Ok("Car exited from parking successfully.");
            else
                return NotFound("Car not found or payment not processed.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}