using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAuthSystem.Application.DTOs.Account;
using TestAuthSystem.Application.Interfaces;

namespace TestAuthSystem.WebApi.Controllers
{
    [Route("api/oauth")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
       
        [HttpGet("get-by-email/{email}")]
        public async Task<IActionResult> GetUserLoginAttemptsByEmail(string email)
        {
            return Ok(await _accountService.GetUserLoginAttemptsByEmail(email));
        }
        [HttpGet("get-by-yearly/{startDate}/{endDate}/{isSuccess}")]
        public async Task<IActionResult> GetYearlyStats(DateTime startDate, DateTime endDate, bool isSuccess)
        {
            return Ok(await _accountService.GetYearlyStats(startDate, endDate, isSuccess));
        }

        [HttpGet("get-by-Hourly/{startDate}/{endDate}/{isSuccess}")]
        public async Task<IActionResult> GetHourlyStats(DateTime startDate, DateTime endDate, bool isSuccess)
        {
            return Ok(await _accountService.GetHourlyStats(startDate, endDate, isSuccess));
        }

        [HttpGet("get-by-GetMonthlyStats/{startDate}/{endDate}/{isSuccess}")]
        public async Task<IActionResult> GetMonthlyStats(DateTime startDate, DateTime endDate, bool isSuccess)
        {
            return Ok(await _accountService.GetMonthlyStats(startDate, endDate, isSuccess));
        }

        [HttpGet("get-stats")]
        public async Task<IActionResult> GetStatistics([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string metric, [FromQuery] bool isSuccess)
        {
            return Ok(await _accountService.GetStatictics(startDate, endDate, metric,isSuccess));
        }
        [HttpGet("get-by-generatesnewrandom/{Userid}")]
        public async Task<IActionResult> generatesnewrandom (Guid Userid)
        {
            return Ok(await _accountService.generatesnewrandom(Userid));
        }
        
    }
}