using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using YLPDotNetCore.RestApi.Controllers;
using YLPDotNetCore.RestApi.Db;
using YLPDotNetCore.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;
//builder.Services.AddScoped<AdoDotNetService>(n => new AdoDotNetService());
//builder.Services.AddScoped<DapperService>(n => new DapperService());

builder.Services.AddScoped(n => new AdoDotNetService(connectionString));
builder.Services.AddScoped(n => new DapperService(connectionString));
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
}, 
ServiceLifetime.Transient, ServiceLifetime.Transient
);

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
