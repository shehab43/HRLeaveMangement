using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HRLeaveMangement.Persistence
{
    public class LeaveManagementDbContextFactory : IDesignTimeDbContextFactory<LeaveMangeMentDbcontext>
    {
        public LeaveMangeMentDbcontext CreateDbContext(string[] args)
        {
            IConfigurationRoot configration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var bulider = new DbContextOptionsBuilder<LeaveMangeMentDbcontext>();
            var connectionString = configration.GetConnectionString("LeaveManagementConnectionString");

            bulider.UseSqlServer(connectionString);

            return new LeaveMangeMentDbcontext(bulider.Options);
        }
    }
}
