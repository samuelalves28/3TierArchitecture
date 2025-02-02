using Business.Interfaces;
using Business.Services;
using Data.Context;
using Data.Implementations.Interfaces;
using Data.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection")!,
    serverVersion,
    sqlOptions => sqlOptions.MigrationsAssembly("Data")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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
