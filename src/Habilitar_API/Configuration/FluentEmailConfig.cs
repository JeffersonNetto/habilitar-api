using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Mail;

namespace Habilitar_API.Configuration
{
    public static class FluentEmailConfig
    {
        public static IServiceCollection AddFluentEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddFluentEmail(configuration["Email:Address"] ?? "habilitar@outlook.com.br")
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient("smtp.live.com", 587)
                {
                    Credentials = new NetworkCredential(configuration["Email:Address"] ?? "habilitar@outlook.com.br", configuration["Email:Password"] ?? "123456"),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                });

            return services;
        }
    }
}
