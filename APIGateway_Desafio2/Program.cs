using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Registrar Scalar (OpenAPI aggregator)
builder.Services.AddOpenApi();

// Registrar Ocelot
builder.Services.AddOcelot();

var app = builder.Build();

// Mapear endpoints de Scalar antes de usar Ocelot
app.MapOpenApi();
app.MapScalarApiReference();

app.Use(async (context, next) =>
{
    if (!context.Request.Headers.ContainsKey("ClientId"))
    {
        // valor de ejemplo; use un id real por cliente en producción
        context.Request.Headers["ClientId"] = "test-client";
    }
    await next();
});

// Iniciar Ocelot
await app.UseOcelot();

app.Run();
