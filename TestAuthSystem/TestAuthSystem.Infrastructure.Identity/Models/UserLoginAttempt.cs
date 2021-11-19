using System;
using System.Collections.Generic;
using System.Text;

namespace TestAuthSystem.Infrastructure.Identity.Models
{
    public class UserLoginAttempt
    {
        public Guid Id { get; set; }
        public DateTime AttemptTime { get; set; }
        public bool IsSuccess { get; set; }
        public User User { get; set; }
    }
}
