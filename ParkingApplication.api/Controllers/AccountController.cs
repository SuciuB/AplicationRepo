using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ParkingApplication;

namespace ParkingApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("accounts")]
        public ActionResult<List<AccountModel>> GetAccounts()
        {
            return Ok(_accountService.ListOfAccounts);
        }

        [HttpPost("payForParking")]
        public IActionResult PayForParking(int userId, DateTime inTime)
        {
            var result = _accountService.PayForParking(userId, inTime);
            if (result)
            {
                return Ok("Payment successful.");
            }
            return BadRequest("Insufficient funds.");
        }

    }
}