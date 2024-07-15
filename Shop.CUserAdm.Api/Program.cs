using Microsoft.EntityFrameworkCore;
using Shop.CUser.Persistence.Context;
using Shop.Customers.IOC.Depedencias;


var builder = WebApplication.CreateBuilder(args);

// Configurando el context (ShopContext)
builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));

// Add services to the container.

builder.Services.AddCUsersDependency();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agrega servicios al contenedor.
builder.Services.AddControllersWithViews();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
