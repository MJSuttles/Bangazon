using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore.Query;
using Npgsql.Internal;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Configure CORS policy to allow frontend requests
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS before routing
app.UseCors();

app.UseHttpsRedirection();

// API Calls

// CART Calls

// GET Customer Cart

app.MapGet("/api/cart/{userId}", (BangazonDbContext db, string userId) =>
{
    Cart cart = db.Carts
        .Include(c => c.CartItems)
        .ThenInclude(ci => ci.Product)
        .FirstOrDefault(c => c.UserId == userId);

    if (cart == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(cart);
});

// Add to Cart

app.MapPost("/api/cart/add", (BangazonDbContext db, string userId, int productId, int quantity) =>
{
    var cart = db.Carts.FirstOrDefault(c => c.UserId == userId);

    if (cart == null)
    {
        cart = new Cart { UserId = userId };
        db.Carts.Add(cart);
        db.SaveChanges();
    }

    var cartItem = db.CartItems.FirstOrDefault(ci => ci.CartId == cart.Id && ci.ProductId == productId);

    if (cartItem == null)
    {
        cartItem = new CartItem { CartId = cart.Id, ProductId = productId, Quantity = quantity };
        db.CartItems.Add(cartItem);
    }
    else
    {
        cartItem.Quantity += quantity;
    }

    db.SaveChanges();
    return Results.Ok(cart);
});

// Add Payment Method to Cart

app.MapPost("/api/cart/add-payment", (BangazonDbContext db, string userId, int paymentMethodId) =>
{
    Cart cart = db.Carts.FirstOrDefault(c => c.UserId == userId);

    if (cart == null)
    {
        return Results.NotFound();
    }

    cart.UserPaymentMethodId = paymentMethodId;
    db.SaveChanges();

    return Results.Ok(cart);
});

// CARTITEMS Calls



// CATEGORY Calls



// ORDER Calls

// GET Orders by Seller

app.MapGet("/api/orders/sellers/{sellerId}", (BangazonDbContext db, string sellerId) =>
{
    List<Order> orders = db.Orders
        .Where(o => o.IsComplete == true && o.OrderItems.Any(oi => oi.SellerId == sellerId))
        .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.Product)
        .ToList();

    if (!orders.Any())
    {
        return Results.NotFound();
    }

    return Results.Ok(orders);
});

// POST then Complete Order (Moves Items to Order and Clears the Cart)

app.MapPost("/api/orders/complete", (BangazonDbContext db, string userId) =>
{
    Cart cart = db.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.UserId == userId);

    if (cart == null || !cart.CartItems.Any())
    {
        return Results.BadRequest("Cart is empty");
    }

    // ✅ Order starts with isComplete = false
    Order order = new Order
    {
        CustomerId = userId,
        UserPaymentMethodId = cart.UserPaymentMethodId,
        IsComplete = false // ✅ Order is not complete until payment is confirmed
    };

    db.Orders.Add(order);
    db.SaveChanges();

    List<OrderItem> orderItems = cart.CartItems.Select(ci => new OrderItem
    {
        OrderId = order.Id,
        ProductId = ci.ProductId,
        Quantity = ci.Quantity,
        SellerId = db.Products.FirstOrDefault(p => p.Id == ci.ProductId)?.SellerId ?? ""
    }).ToList();

    db.OrderItems.AddRange(orderItems);
    db.CartItems.RemoveRange(cart.CartItems); // Clears cart items
    db.Carts.Remove(cart); // Removes cart after checkout
    db.SaveChanges();

    return Results.Ok(order);
});

// ✅ Separate API call to mark order as complete when payment is provided
app.MapPost("/api/orders/confirm-payment/{orderId}", (BangazonDbContext db, int orderId) =>
{
    Order order = db.Orders.FirstOrDefault(o => o.Id == orderId);

    if (order == null)
    {
        return Results.NotFound("Order not found.");
    }

    // ✅ Change isComplete to true once payment is confirmed
    order.IsComplete = true;
    db.SaveChanges();

    return Results.Ok(order);
});

// GET Orders by Customer

app.MapGet("/api/orders/{id}", (BangazonDbContext db, string id) =>
{
    Order order = db.Orders
        .Where(o => o.CustomerId == id)
        .Include(o => o.OrderItems)
        .FirstOrDefault();

    if (order == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(order);
});

// ORDERITEM Calls



// PAYMENTOPTION Calls



// PRODUCT Calls

// GET Products by Id

app.MapGet("/api/products/{id}", (BangazonDbContext db, int id) =>
{
    Product product = db.Products
        .Include(p => p.Category)
        .FirstOrDefault(p => p.Id == id);

    if (product == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(product);
});

// GET All Products

app.MapGet("/api/products", (BangazonDbContext db) =>
{
    return db.Products.ToList();
});

// USER Calls

// Add User

app.MapGet("/api/checkuser/{userId}", (BangazonDbContext db, string userId) =>
{
    var user = db.Users.FirstOrDefault(u => u.Uid == userId);

    if (user == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(user);
});

app.MapPost("/api/register", (BangazonDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/users/{user.Uid}", user);
});

// USERPAYMENTMETHOD Calls



// SEARCH Calls

// GET Search by Product Name

app.MapGet("/api/products/search", (BangazonDbContext db, string searchTerm) =>
{
    var products = db.Products
        .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower())) // ✅ Case-insensitive search
        .Include(p => p.Category) // ✅ Include Category data
        .ToList();

    if (!products.Any())
    {
        return Results.NotFound("No products found.");
    }

    return Results.Ok(products);
});

// GET Search by Seller Name

app.MapGet("/api/sellers/search", (BangazonDbContext db, string searchTerm) =>
{
    var sellerUids = db.Users
        .Where(u => u.FirstName.ToLower().Contains(searchTerm.ToLower())
                 || u.LastName.ToLower().Contains(searchTerm.ToLower()))
        .Select(u => u.Uid)
        .ToList();

    if (!sellerUids.Any())
    {
        return Results.NotFound("No sellers found.");
    }

    var sellersWithProducts = db.Products
        .Where(p => sellerUids.Contains(p.SellerId)) // ✅ Ensure seller has products
        .Select(p => p.SellerId)
        .Distinct()
        .ToList();

    var sellers = db.Users
        .Where(u => sellersWithProducts.Contains(u.Uid)) // ✅ Filter only sellers with products
        .Select(u => new
        {
            u.Uid,
            u.FirstName,
            u.LastName,
            u.Email
        })
        .ToList();

    if (!sellers.Any())
    {
        return Results.NotFound("No matching sellers with products found.");
    }

    return Results.Ok(sellers);
});



app.Run();
