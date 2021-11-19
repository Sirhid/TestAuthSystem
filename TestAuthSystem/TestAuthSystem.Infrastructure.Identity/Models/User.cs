using HRIS.Application.DTOs.Account;
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
        public List<RefreshToken> RefreshTokens { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
