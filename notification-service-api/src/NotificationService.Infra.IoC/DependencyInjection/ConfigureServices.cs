using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Mail;

namespace NotificationService.Infra.IoC.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var handlers = AppDomain.CurrentDomain.Load("NotificationService.Application");
            services.AddMediatR(handlers);

            string senderEmailAddress = configuration["Email:Sender"],
                   smtpEmailAddress = configuration["Email:Smtp"],
                   smtpPassword = configuration["Email:Password"];
            int httpPort = configuration["Email:Port"] != null ? Convert.ToInt32(configuration["Email:Port"]) : 587;

            SmtpClient client = new(smtpEmailAddress, httpPort)
            {
                EnableSsl = true
            };
            NetworkCredential credentials = new(senderEmailAddress, smtpPassword);
            client.Credentials = credentials;

            services.AddFluentEmail(senderEmailAddress)
                    .AddRazorRenderer()
                    .AddSmtpSender(client);

            return services;
        }
    }
}
