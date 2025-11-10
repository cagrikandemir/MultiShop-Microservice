using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.addApplicationServices(builder.Configuration);
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddScoped<CreateAddressCommand>();
//builder.Services.AddScoped<UpdateAddressCommand>();
//builder.Services.AddScoped<RemoveAddressCommands>();
//builder.Services.AddScoped<CreateAddressCommandHandler>();
//builder.Services.AddScoped<UpdateAddressCommandHandler>();
//builder.Services.AddScoped<RemoveAddressCommandHandler>();
//builder.Services.AddScoped<GetAddressByIdQuery>();
//builder.Services.AddScoped<GetAddressQuery>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
