using Microsoft.EntityFrameworkCore;

namespace InsuranceQuoteApp.Data
{
    public class InsuranceQuoteAppDbContext : DbContext
    {
        public InsuranceQuoteAppDbContext(DbContextOptions<InsuranceQuoteAppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<InsurancePlan> InsurancePlans { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add custom configurations here, if needed
        }
    }
}