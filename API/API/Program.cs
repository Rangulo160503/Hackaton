using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios.Leccion;
using Flujo;
using Reglas;
using Servicios;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
//  Servicios base
// -----------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

// -----------------------------
//  Inyección de dependencias
// -----------------------------
builder.Services.AddScoped<ILeccionBosqueFlujo, LeccionBosqueFlujo>();
builder.Services.AddScoped<ILeccionBosqueServicio, LeccionBosqueServicio>();
builder.Services.AddScoped<IConfiguracion, Configuracion>();


// -----------------------------
//  Construir la aplicación
// -----------------------------
var app = builder.Build();

// -----------------------------
//  Middleware pipeline
// -----------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
