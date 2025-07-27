using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyStack.Infrastructure.EF;


namespace WebAPI.EF
{
    public class OrueContextFactory : IDesignTimeDbContextFactory<OrueContext>
    {
        public OrueContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<OrueContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("Orue"));

            return new OrueContext(optionsBuilder.Options);
        }
    }
}
