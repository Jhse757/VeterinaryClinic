using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Data;
using VeterinaryClinic.Services.Implementations;
using VeterinaryClinic.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registrar el DbContext con la cadena de conexión
var connectonString = builder.Configuration.GetConnectionString("MySqlConnection");
if (string.IsNullOrEmpty(connectonString))
{
    throw new InvalidOperationException("La conexión con la base de datos no esta configurada");
}

builder.Services.AddDbContext<AplicationDbContext>(options => 
options.UseMySql(connectonString, ServerVersion.AutoDetect(connectonString)));

// Configurar los repositorios
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IQuoteRepository, QuoteRepository>();
builder.Services.AddScoped<IVetRepository, VetRepository>();

// Configurar Swagger
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
