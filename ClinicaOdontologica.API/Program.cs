using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.API.Data; // Asegúrate de que el namespace sea el correcto

var builder = WebApplication.CreateBuilder(args);

// 1. REGISTRA EL SOPORTE PARA CONTROLADORES (Obligatorio para que funcione el Scaffolder)
builder.Services.AddControllers();

// 2. CONECTA TU BASE DE DATOS POSTGRESQL USANDO TU CADENA "APIContext"
var connectionString = builder.Configuration.GetConnectionString("ClinicaOdontologicaAPIContext");
builder.Services.AddDbContext<ClinicaOdontologicaAPIContext>(options =>
    options.UseNpgsql(connectionString));

// Configuración predeterminada de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3. MAPEA LAS RUTAS DE LOS CONTROLADORES
app.MapControllers();

// Puedes dejar el ejemplo de WeatherForecast abajo si quieres, o borrarlo.
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}