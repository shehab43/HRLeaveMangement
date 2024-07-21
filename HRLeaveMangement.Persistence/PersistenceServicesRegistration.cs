using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Persistence.Reposatory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigrationPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveMangeMentDbcontext>(options =>
               options.UseSqlServer(
             configuration.GetConnectionString("LeaveManagementConnectionString")));

            services.AddScoped(typeof(IGenaricReposatory<>), typeof(GenaricReposatory<>));
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveTypeRepository,LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository,LeaveRequestRepository>();

            return services;
        }
            
            
            
    }
}
