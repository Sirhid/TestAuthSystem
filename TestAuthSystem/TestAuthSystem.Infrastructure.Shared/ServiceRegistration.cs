using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAuthSystem.Application.Interfaces;
using TestAuthSystem.Domain.Settings;
using TestAuthSystem.Infrastructure.Shared.Services;

namespace TestAuthSystem.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
