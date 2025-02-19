using Microsoft.EntityFrameworkCore;

using OnlineShop.Core.Interfaces;
using OnlineShop.Infra.OnlineShop.Infrastructure.Data;
using OnlineShop.Infra.OnlineShop.Infrastructure.Repositories;
using OnlineShop.Infra.OnlineShop.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext to the service container with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add UnitOfWork and Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Add Application services
//builder.Services.AddScoped<IOrderService, OrderService>();

// Register AutoMapper (optional, if you're using AutoMapper for DTO mapping)

// Swagger (optional for testing API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
