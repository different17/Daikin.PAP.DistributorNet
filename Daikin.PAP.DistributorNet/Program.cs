using Daikin.PAP.DistributorNet.Domain.Repositary.AdminTools;
using Daikin.PAP.DistributorNet.Domain.Repositary.AdminTools.RepositaryContracts;
using Daikin.PAP.DistributorNet.Domain.Service.AdminTools;
using Daikin.PAP.DistributorNet.Domain.Service.AdminTools.ServiceContracts;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register IDbConnection
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

builder.Services.AddControllers();
builder.Services.AddScoped<IDistributorRepositary, DistributorRepositary>();
builder.Services.AddScoped<IDistributorService, DistributorService>();
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
