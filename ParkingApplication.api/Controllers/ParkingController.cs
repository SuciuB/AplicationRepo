using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    
public class ParkedCarsController : ControllerBase
{
    private readonly IParkingService _parkingService;

    public ParkedCarsController (IParkingService parkingService)
    { 
        _parkingService = parkingService;
    }

    [HttpGet]
    public ActionResult<List<ParkingModel>> GetListOfParkedCars()
    {
        return Ok(_parkingService.GetParkedCar);
    }

    [HttpPost("parking")]
    public IActionResult AddToParking([FromBody] ParkingModel car)
    {
        try
        {
            _parkingService.AddToParking(car.UserId, car.CarNumber);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        } 
    }

    [HttpDelete("parked-car/{carNumber}")]
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
