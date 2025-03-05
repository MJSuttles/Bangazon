using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore.Query;

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
