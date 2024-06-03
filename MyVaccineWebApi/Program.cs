using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Configurations;
using MyVaccineWebApi.Literals;
using MyVaccineWebApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Inyecci�n de dependencias
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.SetDatabaseConfiguration();
builder.Services.SetMyVaccineAuthConfigutation();
builder.Services.SetDependencyInjection();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
