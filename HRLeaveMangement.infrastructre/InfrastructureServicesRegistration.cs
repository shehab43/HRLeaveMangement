using HRLeaveMangement.Application.Contracts.infrastructre;
using HRLeaveMangement.Application.Models;
using HRLeaveMangement.infrastructre.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.infrastructre
{
    public static class InfrastructureServicesRegistration 
    {
        public static IServiceCollection ConfigurationInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
