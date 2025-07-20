# ✅ Criar a estrutura inicial do projeto

![GitHub repo size](https://img.shields.io/github/repo-size/fzanneti/wex-e2e-csharp)
![GitHub forks](https://img.shields.io/github/forks/fzanneti/wex-e2e-csharp?style=social)
![GitHub Repo stars](https://img.shields.io/github/stars/fzanneti/wex-e2e-csharp?style=social)
![Bootcamp](https://img.shields.io/badge/WEX-End--to--End%20Engineering-blueviolet?logo=vercel&logoColor=white)
![Plataforma](https://img.shields.io/badge/Powered%20by-DIO.io-red?logo=data:image/svg+xml;base64,PHN2ZyBmaWxsPSIjZmZmIiB2aWV3Qm94PSIwIDAgMzIgMzIiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PHBhdGggZD0iTTYuNzEgMy4yNWMtMi44OCAxLjQxLTUuMDcgNC4yMy01LjA3IDcuNzYgMCAzLjU4IDIuMjggNi43IDUuMzMgOC4xNSAxLjgzLS42MiAyLjQtMi4yNiAyLjQtMy44MSAwLS4yMy0uMDItLjQ1LS4wNS0uNjZBLjQ0LjQ0IDAgMDExMC4xIDExYy4yNC0uNzUuMTEtMS41My0uMy0yLjIyQzguOTIgNy45NiA3LjMzIDcuNSA1Ljc0IDcuNjZhNS41NSA1LjU1IDAgM)
![Autor](https://img.shields.io/badge/Autor-fzanneti-blue?style=flat-square&logo=github)

---

Vamos organizar tudo em pastas separadas, já com o que você vai usar no `docker-compose.yml`.

---

### 🗂️ Estrutura que vamos montar:

```

DesafioWEXDockerCompose/
├── html/                 # HTML simples servido pelo Apache
│   └── index.html
├── JarbasBot/            # Projeto ASP.NET Core Web API (nosso JarbasBot)
│   └── (criaremos via dotnet)
└── docker-compose.yml    # Orquestra os dois serviços

```

---

### 📁 1. Criar a pasta principal e estrutura base

```bash

mkdir -p DesafioWEXDockerCompose/html
cd DesafioWEXDockerCompose

```

---

### 🧾 2. Criar o `index.html` (Apache)

No terminal:

```bash

nano html/index.html

```

Cole o conteúdo abaixo como teste de exibição:

```html

<!DOCTYPE html>
<html lang="pt-br">
<head>
  <meta charset="UTF-8">
  <title>Desafio Docker Compose - Fabio Zanneti</title>
</head>
<body>
  <h1>Olá! Página rodando no Apache (httpd) via Docker Compose</h1>
  <p>Criado por Fabio Zanneti para o Bootcamp WEX X DIO.</p>
</body>
</html>

```

Salve com `CTRL + O`, depois `ENTER`, e saia com `CTRL + X`.

---

### 🧱 3. Criar o projeto JarbasBot com C\#

Ainda dentro de `DesafioWEXDockerCompose`, rode:

```bash

dotnet new webapi -n JarbasBot
sudo chown -R fzanneti:fzanneti /DesafioWEXDockerCompose/JarbasBot

```

Esse comando vai criar a pasta `JarbasBot/` com um projeto ASP.NET Core Web API padrão.

---

### ✏️ **Edite seu `Program.cs`**

Adicione a configuração do Kestrel logo após o `CreateBuilder`:

```csharp

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
app.MapControllers();
app.Run();

```

---

### 🔥 Teste o projeto local (opcional)

```bash

cd JarbasBot
dotnet run

```

Se tudo funcionar, você verá:

```

Now listening on: http://localhost:5xxx

```

Você pode acessar o Swagger local em: `http://localhost:5xxx/swagger`

---

### ⬅️ Volte para a raiz do projeto

```bash

cd ..

```

---

📌 **Neste ponto, sua estrutura deve estar assim:**

```bash

DesafioWEXDockerCompose/
├── html/
│   └── index.html
├── JarbasBot/
│   └── (projeto ASP.NET)

```

---

##### ✍️ Criado por: Fabio Zanneti - 🎯 Projeto: WEX - End to End Engineering
[![GitHub](https://img.shields.io/badge/GitHub-fzanneti-181717?style=flat&logo=github)](https://github.com/fzanneti)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-fzanneti-0A66C2?style=flat&logo=linkedin&logoColor=white)](https://linkedin.com/in/fzanneti)