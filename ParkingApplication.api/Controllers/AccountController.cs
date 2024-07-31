using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;
using ParkingApplication.Api.Repositories;

namespace ParkingApplication.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService; 

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public ActionResult<List<AccountModel>> GetAccounts()
    {
        return Ok(_accountService.GetAllCars());
    }

    [HttpPost("Payments")]
    public ActionResult PayForParking([FromBody] PayForParkingRequestModel requestModel)
    {
        var result = _accountService.PayForParking(requestModel.UserId, requestModel.InTime);
        if (result)
        {
            return Ok("Payment successful.");
        }
        return BadRequest("Insufficient funds.");
    }
}

