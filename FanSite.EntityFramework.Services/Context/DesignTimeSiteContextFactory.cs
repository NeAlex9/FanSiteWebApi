using FanSiteService.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FanSite.EntityFramework.Services.Context
{
    public class DesignTimeSiteContextFactory : IDesignTimeDbContextFactory<SiteContext>
    {
        public SiteContext CreateDbContext(string[] args)
        {
            var connectionStringName = "FANSITE";

            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(connectionStringName);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception($"{connectionStringName} environment variable is not set.");
            }

            Console.WriteLine($"Using {connectionStringName} environment variable as a connection string.");

            var builderOptions = new DbContextOptionsBuilder<SiteContext>()
                .UseSqlServer(connectionStringName)
                .Options;
            return new SiteContext(builderOptions);
        }
    }
}
