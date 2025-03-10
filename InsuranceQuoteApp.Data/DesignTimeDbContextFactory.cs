using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InsuranceQuoteApp.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InsuranceQuoteAppDbContext>
    {
        public InsuranceQuoteAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InsuranceQuoteAppDbContext>();
            
            // Use your connection string from appsettings or another configuration method
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            return new InsuranceQuoteAppDbContext(optionsBuilder.Options);
        }
    }
}
