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
  public DbSet<OrderItem> OrderItems { get; set; }

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
        new User {Uid = "6Na5niFGCaUfZz7y9cjbFEq8twj1", FirstName = "Brian", LastName = "Suttles", Email = "rolltiderolldad@gmail.com", Address = "123 Elm Street", City = "Nashville", State = "TN", Zip = "37201"},
        new User {Uid = "l4XlJweAr3USaFL4DW3h2PfIqAC3", FirstName = "Dayna", LastName = "Suttles", Email = "suttles95@gmail.com", Address = "123 Elm Street", City = "Nashville", State = "TN", Zip = "37201"},
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

    modelBuilder.Entity<Product>().HasData(new Product[]
    {
      // Products for Brian Suttles
      new Product {Id = 1, Name = "Rumours", IsAvailable = true, Price = 47.36M, Image = "https://m.media-amazon.com/images/I/71WxpWovLTL._SL1500_.jpg", Description = "Fleetwood Mac's best-selling album.", Quantity = 5, CategoryId = 1, SellerId = "6Na5niFGCaUfZz7y9cjbFEq8twj1"},
      new Product {Id = 2, Name = "Dark Side of the Moon", IsAvailable = true, Price = 51.99M, Image = "https://m.media-amazon.com/images/I/81j3Su+bWjL._SL1500_.jpg", Description = "Classic Pink Floyd album.", Quantity = 3, CategoryId = 1, SellerId = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3"},
      new Product {Id = 3, Name = "Abbey Road", IsAvailable = true, Price = 38.50M, Image = "https://m.media-amazon.com/images/I/81Sl5vNuxBL._SL1500_.jpg", Description = "The Beatles' famous album.", Quantity = 7, CategoryId = 1, SellerId = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3"},
      new Product {Id = 4, Name = "Jagged Little Pill", IsAvailable = true, Price = 15.99M, Image = "https://m.media-amazon.com/images/I/71+WumJptUL._SL1400_.jpg", Description = "Alanis Morissette's breakthrough album.", Quantity = 4, CategoryId = 2, SellerId = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3"},
      new Product {Id = 5, Name = "Nevermind", IsAvailable = true, Price = 29.99M, Image = "https://m.media-amazon.com/images/I/71NRSUUMZXL._SL1400_.jpg", Description = "Nirvana's best-known record.", Quantity = 6, CategoryId = 2, SellerId = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3"},
      new Product {Id = 6, Name = "21", IsAvailable = true, Price = 19.99M, Image = "https://m.media-amazon.com/images/I/71d3FbEovhL._SL1400_.jpg", Description = "Adele's Grammy-winning album.", Quantity = 3, CategoryId = 3, SellerId = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3"},
      new Product {Id = 7, Name = "Born This Way", IsAvailable = true, Price = 22.99M, Image = "https://m.media-amazon.com/images/I/91m3bJ6geTL._SL1500_.jpg", Description = "Lady Gaga's iconic album.", Quantity = 2, CategoryId = 3, SellerId = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3"},
      new Product {Id = 8, Name = "Thriller", IsAvailable = true, Price = 45.00M, Image = "https://m.media-amazon.com/images/I/81WcnNQ-TBL._SL1500_.jpg", Description = "Michael Jackson's best-selling album.", Quantity = 9, CategoryId = 1, SellerId = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3"},
      new Product {Id = 9, Name = "The Wall", IsAvailable = true, Price = 50.00M, Image = "https://m.media-amazon.com/images/I/71OQVoZt3ML._SL1500_.jpg", Description = "Pink Floyd's rock opera.", Quantity = 4, CategoryId = 1, SellerId = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3"},
      new Product {Id = 10, Name = "Back in Black", IsAvailable = true, Price = 39.99M, Image = "https://m.media-amazon.com/images/I/61wq4+PxvFL._SL1400_.jpg", Description = "AC/DC's legendary album.", Quantity = 8, CategoryId = 2, SellerId = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3"},

      // Products for Dayna Suttles
      new Product {Id = 11, Name = "Lover", IsAvailable = true, Price = 39.99M, Image = "https://m.media-amazon.com/images/I/81zWwCEXKPL._SL1500_.jpg", Description = "Taylor Swift's 2019 album with pop anthems.", Quantity = 5, CategoryId = 1, SellerId = "l4XlJweAr3USaFL4DW3h2PfIqAC3"},
      new Product {Id = 12, Name = "1989", IsAvailable = true, Price = 42.99M, Image = "https://m.media-amazon.com/images/I/71r44eosF8L._SL1500_.jpg", Description = "Taylor Swift's award-winning album from 2014.", Quantity = 6, CategoryId = 1, SellerId = "LoBA4EB98KfPtTZ7t8hE2xlbURw1"},
      new Product {Id = 13, Name = "Golden Hour", IsAvailable = true, Price = 35.99M, Image = "https://m.media-amazon.com/images/I/81g8mMUxsnL._SL1500_.jpg", Description = "Kacey Musgraves' Grammy-winning country album.", Quantity = 4, CategoryId = 1, SellerId = "LoBA4EB98KfPtTZ7t8hE2xlbURw1"},
      new Product {Id = 14, Name = "Fearless (Taylor's Version)", IsAvailable = true, Price = 36.50M, Image = "https://m.media-amazon.com/images/I/81bIVb9zTxL._SL1500_.jpg", Description = "Taylor Swift's re-recorded classic country-pop album.", Quantity = 7, CategoryId = 1, SellerId = "LoBA4EB98KfPtTZ7t8hE2xlbURw1"},
      new Product {Id = 15, Name = "Speak Now (Taylor's Version)", IsAvailable = true, Price = 45.99M, Image = "https://m.media-amazon.com/images/I/71qNte6mGBL._SL1500_.jpg", Description = "Taylor Swift's re-recording of her hit album Speak Now.", Quantity = 3, CategoryId = 1, SellerId = "LoBA4EB98KfPtTZ7t8hE2xlbURw1"},
      new Product {Id = 16, Name = "Evermore", IsAvailable = true, Price = 38.00M, Image = "https://m.media-amazon.com/images/I/71JJ0VdEP3L._SL1400_.jpg", Description = "Folklore's sister album from Taylor Swift.", Quantity = 6, CategoryId = 1, SellerId = "LoBA4EB98KfPtTZ7t8hE2xlbURw1"},
      new Product {Id = 17, Name = "Midnights", IsAvailable = true, Price = 39.50M, Image = "https://m.media-amazon.com/images/I/71g2zPSy7cL._SL1500_.jpg", Description = "Taylor Swift's highly anticipated 2022 album.", Quantity = 5, CategoryId = 1, SellerId = "LoBA4EB98KfPtTZ7t8hE2xlbURw1"},
      new Product {Id = 18, Name = "Folklore", IsAvailable = true, Price = 37.99M, Image = "https://m.media-amazon.com/images/I/71A8kMA6lsL._SL1500_.jpg", Description = "Indie-folk album from Taylor Swift featuring Bon Iver.", Quantity = 4, CategoryId = 1, SellerId = "LoBA4EB98KfPtTZ7t8hE2xlbURw1"},
      new Product {Id = 19, Name = "Reputation", IsAvailable = true, Price = 41.99M, Image = "https://m.media-amazon.com/images/I/71-H5A-YxjL._SL1400_.jpg", Description = "Taylor Swift's dark-pop comeback album.", Quantity = 8, CategoryId = 1, SellerId = "LoBA4EB98KfPtTZ7t8hE2xlbURw1"},
      new Product {Id = 20, Name = "Red (Taylor's Version)", IsAvailable = true, Price = 49.99M, Image = "https://m.media-amazon.com/images/I/61KtbxdHUtL._SL1500_.jpg", Description = "Taylor Swift's iconic breakup album, re-recorded.", Quantity = 9, CategoryId = 1, SellerId = "LoBA4EB98KfPtTZ7t8hE2xlbURw1"},

      // Products for Alice Johnson
      new Product {Id = 21, Name = "The Doors", IsAvailable = true, Price = 28.99M, Image = "https://m.media-amazon.com/images/I/81XwnMK0lnL._SL1500_.jpg", Description = "The Doors' legendary debut album featuring 'Light My Fire'.", Quantity = 6, CategoryId = 1, SellerId = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75"},
      new Product {Id = 22, Name = "The Joshua Tree", IsAvailable = true, Price = 29.99M, Image = "https://m.media-amazon.com/images/I/61Qx3-iADfL._SL1200_.jpg", Description = "U2's breakthrough album featuring 'With or Without You'.", Quantity = 6, CategoryId = 1, SellerId = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75"},
      new Product {Id = 23, Name = "Revolver", IsAvailable = true, Price = 31.50M, Image = "https://m.media-amazon.com/images/I/71-1XnQy3-L._SL1500_.jpg", Description = "The Beatles' experimental classic from 1966.", Quantity = 4, CategoryId = 1, SellerId = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75"},
      new Product {Id = 24, Name = "A Night at the Opera", IsAvailable = true, Price = 38.99M, Image = "https://m.media-amazon.com/images/I/71sN5JB01cL._SL1500_.jpg", Description = "Queen's epic album featuring 'Bohemian Rhapsody'.", Quantity = 7, CategoryId = 1, SellerId = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75"},
      new Product {Id = 25, Name = "Electric Ladyland", IsAvailable = true, Price = 36.99M, Image = "https://m.media-amazon.com/images/I/71J07CmmyxL._SL1200_.jpg", Description = "Jimi Hendrix's groundbreaking double album.", Quantity = 5, CategoryId = 1, SellerId = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75"},
      new Product {Id = 26, Name = "The Rise and Fall of Ziggy Stardust", IsAvailable = true, Price = 27.99M, Image = "https://m.media-amazon.com/images/I/81Ox3bH8K9L._SL1500_.jpg", Description = "David Bowie's concept album featuring 'Starman'.", Quantity = 6, CategoryId = 1, SellerId = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75"},
      new Product {Id = 27, Name = "Brothers in Arms", IsAvailable = true, Price = 32.99M, Image = "https://m.media-amazon.com/images/I/71b6M0XLvSL._SL1500_.jpg", Description = "Dire Straits' biggest album featuring 'Money for Nothing'.", Quantity = 5, CategoryId = 1, SellerId = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75"},
      new Product {Id = 28, Name = "Moondance", IsAvailable = true, Price = 31.99M, Image = "https://m.media-amazon.com/images/I/81Ug7cMZk8L._SL1500_.jpg", Description = "Van Morrison’s most celebrated album, featuring 'Into the Mystic'.", Quantity = 5, CategoryId = 1, SellerId = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75"},
      new Product {Id = 29, Name = "The Velvet Underground & Nico", IsAvailable = true, Price = 39.99M, Image = "https://m.media-amazon.com/images/I/81vBx5EmKXL._SL1500_.jpg", Description = "A highly influential album with Andy Warhol's iconic banana cover.", Quantity = 6, CategoryId = 1, SellerId = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75"},
      new Product {Id = 30, Name = "Hunky Dory", IsAvailable = true, Price = 30.99M, Image = "https://m.media-amazon.com/images/I/81a1DlQF7hL._SL1500_.jpg", Description = "Another classic from David Bowie featuring 'Life on Mars?'.", Quantity = 7, CategoryId = 1, SellerId = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75"},

      // Products for Bob Brown
      new Product {Id = 31, Name = "London Calling", IsAvailable = true, Price = 37.99M, Image = "https://m.media-amazon.com/images/I/81AwUyc+KHL._SL1500_.jpg", Description = "The Clash's iconic punk rock double album.", Quantity = 6, CategoryId = 1, SellerId = "fa80e4a1-53b7-4784-ab59-6574dea65bb0"},
      new Product {Id = 32, Name = "Purple Rain", IsAvailable = true, Price = 33.50M, Image = "https://m.media-amazon.com/images/I/81TlfZbcY+L._SL1500_.jpg", Description = "Prince's legendary album featuring 'When Doves Cry'.", Quantity = 5, CategoryId = 1, SellerId = "fa80e4a1-53b7-4784-ab59-6574dea65bb0"},
      new Product {Id = 33, Name = "Born to Run", IsAvailable = true, Price = 28.99M, Image = "https://m.media-amazon.com/images/I/91pGDOS2yYL._SL1500_.jpg", Description = "Bruce Springsteen's breakthrough album.", Quantity = 7, CategoryId = 1, SellerId = "fa80e4a1-53b7-4784-ab59-6574dea65bb0"},
      new Product {Id = 34, Name = "Pet Sounds", IsAvailable = true, Price = 36.99M, Image = "https://m.media-amazon.com/images/I/81ZXxdrUwcL._SL1500_.jpg", Description = "The Beach Boys' classic album that redefined pop music.", Quantity = 5, CategoryId = 1, SellerId = "fa80e4a1-53b7-4784-ab59-6574dea65bb0"},
      new Product {Id = 35, Name = "Hotel California", IsAvailable = true, Price = 34.99M, Image = "https://m.media-amazon.com/images/I/71iCZPH5DqL._SL1500_.jpg", Description = "Eagles' legendary album featuring the title track.", Quantity = 4, CategoryId = 1, SellerId = "fa80e4a1-53b7-4784-ab59-6574dea65bb0"},
      new Product {Id = 36, Name = "Tapestry", IsAvailable = true, Price = 27.99M, Image = "https://m.media-amazon.com/images/I/91wPiHtmwQL._SL1500_.jpg", Description = "Carole King's masterpiece featuring 'You've Got a Friend'.", Quantity = 6, CategoryId = 1, SellerId = "fa80e4a1-53b7-4784-ab59-6574dea65bb0"},
      new Product {Id = 37, Name = "Bridge Over Troubled Water", IsAvailable = true, Price = 32.99M, Image = "https://m.media-amazon.com/images/I/81KrqZuxNQL._SL1500_.jpg", Description = "Simon & Garfunkel's classic folk-rock album.", Quantity = 5, CategoryId = 1, SellerId = "fa80e4a1-53b7-4784-ab59-6574dea65bb0"},
      new Product {Id = 38, Name = "Superfly", IsAvailable = true, Price = 31.50M, Image = "https://m.media-amazon.com/images/I/91RCpMFXxQL._SL1500_.jpg", Description = "Curtis Mayfield's groundbreaking soul-funk album.", Quantity = 4, CategoryId = 1, SellerId = "fa80e4a1-53b7-4784-ab59-6574dea65bb0"},
      new Product {Id = 39, Name = "Blood on the Tracks", IsAvailable = true, Price = 35.50M, Image = "https://m.media-amazon.com/images/I/81DBw5cAzQL._SL1500_.jpg", Description = "Bob Dylan's deeply personal masterpiece.", Quantity = 6, CategoryId = 1, SellerId = "fa80e4a1-53b7-4784-ab59-6574dea65bb0"},
      new Product {Id = 40, Name = "Let It Be", IsAvailable = true, Price = 30.99M, Image = "https://m.media-amazon.com/images/I/71qlM3JjXQL._SL1500_.jpg", Description = "The Beatles' final studio album.", Quantity = 7, CategoryId = 1, SellerId = "fa80e4a1-53b7-4784-ab59-6574dea65bb0"},

      // Products for Charlie Miller
      new Product {Id = 41, Name = "Licensed to Ill", IsAvailable = true, Price = 27.99M, Image = "https://m.media-amazon.com/images/I/91tZCYO2iIL._SL1500_.jpg", Description = "Beastie Boys' genre-defining hip-hop album.", Quantity = 5, CategoryId = 1, SellerId = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a"},
      new Product {Id = 42, Name = "The Queen Is Dead", IsAvailable = true, Price = 34.99M, Image = "https://m.media-amazon.com/images/I/81G7lzC5VLL._SL1500_.jpg", Description = "The Smiths’ iconic post-punk album.", Quantity = 6, CategoryId = 1, SellerId = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a"},
      new Product {Id = 43, Name = "Blood Sugar Sex Magik", IsAvailable = true, Price = 33.50M, Image = "https://m.media-amazon.com/images/I/71GywSYBKlL._SL1500_.jpg", Description = "Red Hot Chili Peppers’ funk-rock breakthrough.", Quantity = 4, CategoryId = 1, SellerId = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a"},
      new Product {Id = 44, Name = "Automatic for the People", IsAvailable = true, Price = 36.99M, Image = "https://m.media-amazon.com/images/I/81wUOBjHboL._SL1500_.jpg", Description = "R.E.M.'s critically acclaimed album.", Quantity = 7, CategoryId = 1, SellerId = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a"},
      new Product {Id = 45, Name = "Doolittle", IsAvailable = true, Price = 30.99M, Image = "https://m.media-amazon.com/images/I/81s6KZp1ajL._SL1500_.jpg", Description = "The Pixies’ alternative rock classic.", Quantity = 6, CategoryId = 1, SellerId = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a"},
      new Product {Id = 46, Name = "Horses", IsAvailable = true, Price = 38.99M, Image = "https://m.media-amazon.com/images/I/81MbMS+FDsL._SL1500_.jpg", Description = "Patti Smith's influential punk album.", Quantity = 5, CategoryId = 1, SellerId = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a"},
      new Product {Id = 47, Name = "Appetite for Destruction", IsAvailable = true, Price = 29.99M, Image = "https://m.media-amazon.com/images/I/81pLDAZV4LL._SL1500_.jpg", Description = "Guns N' Roses' explosive debut album.", Quantity = 5, CategoryId = 1, SellerId = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a"},
      new Product {Id = 48, Name = "Rumours", IsAvailable = true, Price = 35.99M, Image = "https://m.media-amazon.com/images/I/81vw+8N6WQL._SL1500_.jpg", Description = "Fleetwood Mac’s most celebrated album.", Quantity = 7, CategoryId = 1, SellerId = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a"},
      new Product {Id = 49, Name = "Back in Black", IsAvailable = true, Price = 37.50M, Image = "https://m.media-amazon.com/images/I/81zBfuU6+RL._SL1500_.jpg", Description = "AC/DC’s best-selling rock album of all time.", Quantity = 6, CategoryId = 1, SellerId = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a"},
      new Product {Id = 50, Name = "Master of Puppets", IsAvailable = true, Price = 33.99M, Image = "https://m.media-amazon.com/images/I/91zRVgJavIL._SL1500_.jpg", Description = "Metallica’s iconic thrash metal album.", Quantity = 5, CategoryId = 1, SellerId = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a"}
    });
  }
}
