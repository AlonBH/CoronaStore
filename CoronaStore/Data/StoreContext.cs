using CoronaStore.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaStore.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext (DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.ProductId, op.OrderId});

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(o => o.OrderId);

            // modelBuilder.Entity<Customer>().HasMany(customer => customer.Orders)
            //     .WithRequired(order => order.Customer)
            //     .HasForeignKey(order => order.CustomerId);

        }
    }
}
