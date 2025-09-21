using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using JarbasBot.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Adiciona serviços ao container
builder.Services.AddControllers();
builder.Services.AddHttpClient<OpenRouterService>();
builder.Services.AddSingleton<OpenRouterService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Endpoint de chat
app.MapPost("/chat", async (OpenRouterService ai, [FromBody] string prompt) =>
{
    var reply = await ai.AskJarbas(prompt);
    return Results.Ok(new { response = reply });
});

app.UseCors("AllowAll");

// Configura o pipeline de requisição
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint de teste
app.MapGet("/hello", () => new { Message = "Olá Fabio, o backend está funcionando 🚀" });
app.UseDefaultFiles();   // Serve index.html automaticamente
app.UseStaticFiles();    // Permite servir arquivos estáticos (JS, CSS)
app.UseAuthorization();
app.MapControllers();
app.Run();