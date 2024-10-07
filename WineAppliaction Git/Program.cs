using Data;
using Data.Repo;
using Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<WineRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IWineService, WineServices>();
builder.Services.AddDbContext<WineContext>(dbContextOptions => dbContextOptions.UseSqlite(
builder.Configuration["ConnectionStrings:DBConnectionString"]));



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
