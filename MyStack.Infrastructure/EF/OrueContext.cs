using Microsoft.EntityFrameworkCore;
using MyStack.KeepAlive.Domain;
using MyStack.Money.Domain;

namespace MyStack.Infrastructure.EF
{
    
    public class OrueContext : DbContext
    {
        public OrueContext(DbContextOptions<OrueContext> options)
            : base(options) { }

        public DbSet<Trade> Trades { get; set; }
        public DbSet<VersionInfo> Versions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>().ToTable("Trades");
            modelBuilder.Entity<Trade>().Property(t => t.Type).HasConversion<int>();
            modelBuilder.Entity<Trade>().Property(t => t.InstrumentType).HasConversion<int>();
            modelBuilder.Entity<Trade>().Property(t => t.Currency).HasConversion<int>();

            modelBuilder.Entity<VersionInfo>().ToTable("VersionInfo");
            modelBuilder.Entity<VersionInfo>().Property(v => v.Value).HasMaxLength(20);
        }
    }
}
