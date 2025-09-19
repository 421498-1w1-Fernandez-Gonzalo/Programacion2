using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiEntityFramework.Data.Repositories;
using WebApiEntityFramework.Models;
using WebApiEntityFramework.Services;
using System.Text.Json.Serialization; // Asegúrate de tener este using

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Facturacion_programacionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IArticulosService, ArticulosService>();
builder.Services.AddScoped<IArticuloRepository, ArticulosRepository>();
builder.Services.AddScoped<IFacturasService, FacturasService>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();

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
