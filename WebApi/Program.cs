using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Articulos_Repository;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Factura_Repository;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.services;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("https://localhost:7044")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IArticuloService, ArticuloService>();
builder.Services.AddScoped<IArticulosRepository, ArticulosRepository>();
builder.Services.AddScoped<IDataHelper, DataHelper>();
builder.Services.AddScoped<IFacturaService, FacturasService>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
