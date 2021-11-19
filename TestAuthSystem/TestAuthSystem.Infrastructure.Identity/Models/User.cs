using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TestAuthSystem.Application.DTOs.Account;

namespace TestAuthSystem.Infrastructure.Identity.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            UserLoginAttempts = new HashSet<UserLoginAttempt>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserLoginAttempt> UserLoginAttempts { get; set; }
    }
}
