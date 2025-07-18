using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using JarbasBot.Services;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeta o serviço do Jarbas
builder.Services.AddSingleton<OpenAiService>();

var app = builder.Build();

app.UseCors("AllowAll");

// Configura o pipeline de requisição
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS é desativado porque estamos rodando via Docker sem certificado
// app.UseHttpsRedirection(); ❌ (não necessário se usando apenas HTTP)

app.UseAuthorization();
app.MapControllers(); // ESSENCIAL para rotas como /api/chat
app.Run();