//Program.cs
using ProyectoIProgra2.Data;
using ProyectoIProgra2.Servicios;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<MyAppDbContext>();

builder.Services.AddScoped<IBloqueoMesaServicio, BloqueoMesaServicio>();

builder.Services.AddScoped<IClienteServicio, ClienteServicio>();

builder.Services.AddScoped<IListaDeEsperaServicio, ListaDeEsperaServicio>();

builder.Services.AddScoped<IMesaServicio, MesaServicio>();

builder.Services.AddScoped<IReservaServicio, ReservaServicio>();

builder.Services.AddScoped<ITurnoServicio, TurnoServicio>();

builder.Services.AddScoped<IZonaServicio, ZonaServicio>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
