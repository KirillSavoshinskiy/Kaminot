using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PaymentSystem> PaymentSystems { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Payment>().HasOne(c => c.Currency).WithMany(p => p.Payments);
            builder.Entity<Payment>().HasOne(p => p.PaymentSystem).WithMany(p => p.Payments);
            builder.Entity<PaymentSystem>().HasMany(c => c.Currencies).WithMany(p => p.PaymentSystems);
            builder.Entity<PaymentSystem>().HasMany(c => c.Payments).WithOne(p => p.PaymentSystem);
        }
    }
}
