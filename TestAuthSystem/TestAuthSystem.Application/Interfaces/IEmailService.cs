using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestAuthSystem.Application.DTOs.Email;

namespace TestAuthSystem.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
