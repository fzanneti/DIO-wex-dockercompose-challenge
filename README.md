# WEX - End to End Engineering

## JarbasBot

![GitHub repo size](https://img.shields.io/github/repo-size/fzanneti/wex-e2e-csharp)
![GitHub forks](https://img.shields.io/github/forks/fzanneti/wex-e2e-csharp?style=social)
![GitHub Repo stars](https://img.shields.io/github/stars/fzanneti/wex-e2e-csharp?style=social)
![Bootcamp](https://img.shields.io/badge/WEX-End--to--End%20Engineering-blueviolet?logo=vercel&logoColor=white)
![Plataforma](https://img.shields.io/badge/Powered%20by-DIO.io-red?logo=data:image/svg+xml;base64,PHN2ZyBmaWxsPSIjZmZmIiB2aWV3Qm94PSIwIDAgMzIgMzIiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PHBhdGggZD0iTTYuNzEgMy4yNWMtMi44OCAxLjQxLTUuMDcgNC4yMy01LjA3IDcuNzYgMCAzLjU4IDIuMjggNi43IDUuMzMgOC4xNSAxLjgzLS42MiAyLjQtMi4yNiAyLjQtMy44MSAwLS4yMy0uMDItLjQ1LS4wNS0uNjZBLjQ0LjQ0IDAgMDExMC4xIDExYy4yNC0uNzUuMTEtMS41My0uMy0yLjIyQzguOTIgNy45NiA3LjMzIDcuNSA1Ljc0IDcuNjZhNS41NSA1LjU1IDAgM)
![Autor](https://img.shields.io/badge/Autor-fzanneti-blue?style=flat-square&logo=github)

> Um assistente virtual carismático, despojado e pronto para te ajudar com bom humor, rodando em ASP.NET Core com integração à OpenRouter via API!

---

<img src="https://github.com/fzanneti/DIO-wex-dockercompose-challenge/blob/main/Assets/images/bot.jpg" alt="Bot" width="600px">

### Sobre o Projeto

O **JarbasBot** é um projeto de chatbot que simula uma personalidade extrovertida e direta, utilizando a API da [OpenRouter.ai](https://openrouter.ai) com modelos LLM gratuitos como o `mistralai/mistral-small`, `meta-llama/llama-4-maverick` e outros.

Projeto desenvolvido como parte do Desafio WEX / DIO - Docker Compose Challenge, com aprimoramento para aplicação real utilizando C# (.NET 8), integração com IA (OpenRouter), API REST e Frontend customizado.

---

### Descrição

O projeto foi idealizado para demonstrar o uso do Docker Compose, servindo:

- Uma aplicação web frontend (HTML/CSS/JS)   
- Uma API em .NET 8 (C#) que se comunica com o serviço de IA.   

Para fins de desafio acadêmico, foi incluído um container **Apache HTTP Server** para servir o frontend localmente.

---

### Tecnologias

- Docker & Docker Compose    
- Apache HTTP Server (local)     
- ASP.NET Core 8 (API JarbasBot)     
- OpenRouter API (Integração com IA)    
- HTML / CSS / JS     

---

### Execução Local com Docker Compose

**Pré-requisitos:**

- Docker instalado     
- Docker Compose instalado    

Arquivo .env configurado com:

```bash

- OPENAI_API_KEY=sua_chave_openrouter

```

---

### Instruções: 

1. Clone o repositório:

```bash

git clone https://github.com/fzanneti/DIO-wex-dockercompose-challenge.git
cd DIO-wex-dockercompose-challenge

```

2. Execute o Docker Compose:

```bash

docker-compose up --build

```

---

### Serviços Disponíveis

|Serviço	URL|Acesso|
|---|---|
|Apache (Frontend)|http://localhost:8080|
|JarbasBot API|http://localhost:5000/api/chat|

---

### ☁️ Deploy em Produção (Railway)

Para a produção no Railway, utilizei uma abordagem diferente da proposta original do desafio para garantir uma aplicação funcional hospedada em nuvem:

- O **Frontend (HTML/CSS/JS)** foi incorporado diretamente na aplicação ASP.NET Core, servido a partir da pasta wwwroot.
- O **Apache** não foi utilizado no deploy do Railway, pois o Railway não suporta múltiplos containers em um único serviço.


> Observação: Essa adaptação foi necessária para possibilitar a publicação funcional do projeto em ambiente de produção na nuvem, respeitando as limitações da plataforma Railway.

### URL de Produção

<img src="https://github.com/fzanneti/wex-dockercompose-challenge/blob/main/assets/images/Project-Jarbas-Bot.gif" width="800px">

🔗[Acesse](https://wex-dockercompose-challenge-production.up.railway.app)

---

### Funcionalidades

Envie perguntas pelo frontend e o JarbasBot responde com bom humor, informalidade e integração com IA.

**API RESTful com endpoint:**

```bash

POST /api/chat
{
    "question": "sua pergunta"
}

```

---

##### ✍️ Seção criada por: *Fabio Zanneti* - 🎯 Bootcamp: **WEX - End to End Engineering**
[![GitHub](https://img.shields.io/badge/GitHub-fzanneti-181717?style=flat&logo=github)](https://github.com/fzanneti)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-fzanneti-0A66C2?style=flat&logo=linkedin&logoColor=white)](https://linkedin.com/in/fzanneti)