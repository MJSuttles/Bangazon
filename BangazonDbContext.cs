using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using Microsoft.EntityFrameworkCore; // ✅ Required for UseSqlite()


public class BangazonDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<Seller> Sellers { get; set; }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Store> Stores { get; set; }
  public DbSet<PaymentType> PaymentTypes { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<CartItem> CartItems { get; set; }
  public DbSet<Cart> Carts { get; set; }
  public DbSet<Order> Orders { get; set; }

  public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
  {

  }
}
