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
        [HttpGet("get-stats")]
        public async Task<IActionResult> GetStatistics([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string metric, [FromQuery] bool isSuccess)
        {
            return Ok(await _accountService.GetStatictics(startDate, endDate, metric,isSuccess));
        }
        
    }
}