using Microsoft.EntityFrameworkCore;
using MyStack.Money.Domain;

namespace WebAPI.EF
{
    public class OrueContext : DbContext
    {
        public OrueContext(DbContextOptions<OrueContext> options)
            : base(options) { }

        public DbSet<Trade> Trades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>().ToTable("Trades");

            modelBuilder.Entity<Trade>().Property(t => t.Type).HasConversion<int>();
            modelBuilder.Entity<Trade>().Property(t => t.InstrumentType).HasConversion<int>();
            modelBuilder.Entity<Trade>().Property(t => t.Currency).HasConversion<int>();
        }
    }
}
