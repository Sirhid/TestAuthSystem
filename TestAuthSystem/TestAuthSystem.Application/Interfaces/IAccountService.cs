using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestAuthSystem.Application.DTOs.Account;
using TestAuthSystem.Application.Wrappers;

namespace TestAuthSystem.Application.Interfaces
{
    public interface IAccountService
    {
        Task<List<UserLoginAttemptsDTO>> GetUserLoginAttemptsByEmail(string email);
        Task<List<MetricStatisticDTO>> GetStatictics(DateTime startDate, DateTime endDate, string metric, bool isSuccess);
    }
}
