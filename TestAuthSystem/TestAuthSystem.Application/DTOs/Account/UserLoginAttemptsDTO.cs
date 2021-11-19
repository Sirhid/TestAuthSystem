using System;
using System.Collections.Generic;
using System.Text;

namespace TestAuthSystem.Application.DTOs.Account
{
    public class UserLoginAttemptsDTO
    {
        public Guid Id { get; set; }
        public DateTime AttemptTime { get; set; }
        public bool IsSuccess { get; set; }
    }
}
