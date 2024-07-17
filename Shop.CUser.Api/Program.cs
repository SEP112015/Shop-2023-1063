
using Shop.Infrastructure.Logger.Interfaces;
using Shop.Infrastructure.Logger.Services;

using Shop.Customers.IOC.Depedencias;
using Microsoft.EntityFrameworkCore;
using Shop.CUser.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));

builder.Services.AddCUsersDependency();

builder.Services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();








