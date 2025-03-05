using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore.Query;
using Npgsql.Internal;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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

// Complete Order (Moves Items to Order and Clears the Cart)

app.MapPost("/api/orders/complete", (BangazonDbContext db, string userId) =>
{
    Cart cart = db.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.UserId == userId);

    if (cart == null || !cart.CartItems.Any())
    {
        return Results.BadRequest("Cart is empty");
    }

    Order order = new Order
    {
        CustomerId = userId,
        UserPaymentMethodId = cart.UserPaymentMethodId,
        IsAvailable = true
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
    db.CartItems.RemoveRange(cart.CartItems); // Clears cart Items
    db.Carts.Remove(cart); // Removes cart after checkout
    db.SaveChanges();

    return Results.Ok(order);
});

// CARTITEMS Calls



// CATEGORY Calls



// ORDER Calls

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

// GET All Products

app.MapGet("/api/products", (BangazonDbContext db) =>
{
    return db.Products.ToList();
});

// USER Calls

// Add User

app.MapPost("/api/register", (BangazonDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/users/{user.Uid}", user);
});

// USERPAYMENTMETHOD Calls




app.Run();
