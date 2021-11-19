using System;
using System.Collections.Generic;
using System.Text;

namespace TestAuthSystem.Application.DTOs.Account
{
   public class UserDTO
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserLoginAttemptsDTO> loginattempts { get; set; }

       
    }
}
