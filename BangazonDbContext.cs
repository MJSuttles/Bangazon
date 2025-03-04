using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using Microsoft.EntityFrameworkCore; // ✅ Required for UseSqlite()

public class BangazonDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<PaymentOption> PaymentOptions { get; set; }
  public DbSet<UserPaymentMethod> UserPaymentMethods { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<CartItem> CartItems { get; set; }
  public DbSet<Cart> Carts { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<OrderItem> OrdersItems { get; set; }

  public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // ✅ Define `Uid` as the primary key for User
    modelBuilder.Entity<User>()
        .HasKey(u => u.Uid);  // ✅ Set primary key to Uid (string)

    // ✅ Define One-to-One Relationship: User → Cart
    modelBuilder.Entity<Cart>()
        .HasOne(c => c.User)
        .WithOne()
        .HasForeignKey<Cart>(c => c.UserId)
        .HasPrincipalKey<User>(u => u.Uid)  // ✅ Correct usage (no type arguments)
        .OnDelete(DeleteBehavior.Cascade);

    // ✅ Define One-to-Many Relationship: User → Orders
    modelBuilder.Entity<Order>()
        .HasOne(o => o.User)
        .WithMany(u => u.Orders)
        .HasForeignKey(o => o.CustomerId)
        .HasPrincipalKey(u => u.Uid);  // ✅ Correct usage

    // ✅ Define One-to-Many Relationship: User → Payment Methods
    modelBuilder.Entity<UserPaymentMethod>()
        .HasOne(upm => upm.User)
        .WithMany(u => u.UserPaymentMethods)
        .HasForeignKey(upm => upm.UserId)
        .HasPrincipalKey(u => u.Uid);  // ✅ Correct usage

    // ✅ Seed Data
    modelBuilder.Entity<User>().HasData(new User[]
    {
        new User {Uid = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3", FirstName = "Brian", LastName = "Suttles", Email = "rolltiderolldad@gmail.com", Address = "123 Elm Street", City = "Nashville", State = "TN", Zip = "37201"},
        new User {Uid = "LoBA4EB98KfPtTZ7t8hE2xlbURw1", FirstName = "Dayna", LastName = "Suttles", Email = "suttles95@gmail.com", Address = "123 Elm Street", City = "Nashville", State = "TN", Zip = "37201"},
        new User {Uid = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75", FirstName = "Alice", LastName = "Johnson", Email = "alicej@example.com", Address = "789 Pine Street", City = "Atlanta", State = "GA", Zip = "30301"},
        new User {Uid = "fa80e4a1-53b7-4784-ab59-6574dea65bb0", FirstName = "Bob", LastName = "Brown", Email = "bobb@example.com", Address = "321 Maple Avenue", City = "Charlotte", State = "NC", Zip = "28202"},
        new User {Uid = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a", FirstName = "Charlie", LastName = "Miller", Email = "charliem@example.com", Address = "654 Cedar Road", City = "Louisville", State = "KY", Zip = "40202"}
    });

    modelBuilder.Entity<Category>().HasData(new Category[]
    {
      new Category {Id = 1, Title = "Vinyl"},
      new Category {Id = 2, Title = "Cassette"},
      new Category {Id = 3, Title = "Compact Disc"}
    });

    modelBuilder.Entity<PaymentOption>().HasData(new PaymentOption[]
    {
      new PaymentOption {Id = 1, Type = "Credit Card"},
      new PaymentOption {Id = 2, Type = "Apple Pay"},
      new PaymentOption {Id = 3, Type = "Google Pay"},
      new PaymentOption {Id = 4, Type = "PayPal"}
    });
  }  // ✅ Closing brace for OnModelCreating
}  // ✅ Closing brace for BangazonDbContext
