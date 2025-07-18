# 🤖 JarbasBot

![GitHub repo size](https://img.shields.io/github/repo-size/fzanneti/wex-e2e-csharp)
![GitHub forks](https://img.shields.io/github/forks/fzanneti/wex-e2e-csharp?style=social)
![GitHub Repo stars](https://img.shields.io/github/stars/fzanneti/wex-e2e-csharp?style=social)
![Bootcamp](https://img.shields.io/badge/WEX-End--to--End%20Engineering-blueviolet?logo=vercel&logoColor=white)
![Plataforma](https://img.shields.io/badge/Powered%20by-DIO.io-red?logo=data:image/svg+xml;base64,PHN2ZyBmaWxsPSIjZmZmIiB2aWV3Qm94PSIwIDAgMzIgMzIiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PHBhdGggZD0iTTYuNzEgMy4yNWMtMi44OCAxLjQxLTUuMDcgNC4yMy01LjA3IDcuNzYgMCAzLjU4IDIuMjggNi43IDUuMzMgOC4xNSAxLjgzLS42MiAyLjQtMi4yNiAyLjQtMy44MSAwLS4yMy0uMDItLjQ1LS4wNS0uNjZBLjQ0LjQ0IDAgMDExMC4xIDExYy4yNC0uNzUuMTEtMS41My0uMy0yLjIyQzguOTIgNy45NiA3LjMzIDcuNSA1Ljc0IDcuNjZhNS41NSA1LjU1IDAgM)
![Autor](https://img.shields.io/badge/Autor-fzanneti-blue?style=flat-square&logo=github)

> Um assistente virtual carismático, despojado e pronto para te ajudar com bom humor, rodando em ASP.NET Core com integração à OpenRouter via API!

---

### 📌 Sobre o Projeto

O **JarbasBot** é um projeto de chatbot que simula uma personalidade extrovertida e direta, utilizando a API da [OpenRouter.ai](https://openrouter.ai) com modelos LLM gratuitos como o `mistralai/mistral-small`, `meta-llama/llama-4-maverick` e outros.

Ele responde via:
- **API REST** (`/api/chat`)
- **Interface Web (HTML + JS)** simples para facilitar testes

<img src="https://github.com/fzanneti/wex-dockercompose-challenge/blob/main/Bot/assets/images/Project-Jarbas-Bot.gif" width="800px" />

---

### 🚀 Tecnologias Utilizadas

- [ASP.NET Core 8.0](https://learn.microsoft.com/aspnet/core)
- [C#](https://learn.microsoft.com/dotnet/csharp/)
- [Docker & Docker Compose](https://docs.docker.com/)
- [OpenRouter.ai](https://openrouter.ai) (como alternativa à OpenAI)
- HTML/CSS/JS puro

---

### 🧠 Personalidade do Jarbas

Jarbas é um assistente que responde com bom humor e gírias. Você pode adaptar sua personalidade no código, dentro do serviço `OpenAiService.cs`, no conteúdo do papel `system`.

---

### 📂 Estrutura do Projeto

```

Bot/
├── docker-compose.yml
├── html/                     # Interface Web
│   ├── index.html
│   ├── style.css
│   └── app.js
└── JarbasBot/                # Projeto .NET
├── Controllers/
│   └── ChatController.cs
├── Models/
│   ├── ChatRequest.cs
│   └── ChatResponse.cs
├── Services/
│   └── OpenAiService.cs
├── Program.cs
├── JarbasBot.csproj
└── Dockerfile

```

---

### ⚙️ Como Executar com Docker Compose

> Certifique-se de ter o [Docker instalado](https://docs.docker.com/get-docker/).

```bash

# Na raiz do projeto
docker-compose up --build

```

* A API do Jarbas estará disponível em: `http://localhost:5000/api/chat`
* A interface web estará acessível em: `http://localhost:8080`

---

## 🌐 Como Usar

### 🧪 Via Swagger

Acesse: `http://localhost:5000/swagger`

### 📦 Via cURL

```bash

curl -X POST http://localhost:5000/api/chat \
  -H "Content-Type: application/json" \
  -d '{"question":"Quem é você?"}'

```

### 🖥️ Via Interface Web

Abra no navegador: `http://localhost:8080`

---

### 🔐 Variáveis de Ambiente

Configure sua chave da OpenRouter no arquivo `.env`:

```env

OPENAI_API_KEY=sk-or-xxxxxxxxxxxxxxxxxxxx

```

> ⚠️ O arquivo `.env` **não deve ser enviado ao GitHub** — certifique-se de listá-lo no `.gitignore`.

---

### 💡 O que esse Dockerfile faz?

| Etapa        | Descrição                                                |
| ------------ | -------------------------------------------------------- |
| `build`      | Usa imagem com .NET SDK para compilar o projeto          |
| `runtime`    | Usa imagem leve com apenas o ASP.NET para rodar o Jarbas |
| `COPY`       | Move os arquivos compilados da build para o runtime      |
| `ENTRYPOINT` | Define o comando para iniciar a aplicação .NET           |

---

### 🛠️ Melhorias Futuras

* [ ] Autenticação por chave no front
* [ ] Deploy em nuvem (Render / Railway)
* [ ] Modo de histórico de conversa
* [ ] Personalização da personalidade em tempo real

---

### 📄 Licença

Este projeto está licenciado sob os termos da **MIT License**.

---

##### ✍️ Criado com ❤️ por: Fabio Zanneti - 🎯 Projeto: WEX - End to End Engineering
[![GitHub](https://img.shields.io/badge/GitHub-fzanneti-181717?style=flat&logo=github)](https://github.com/fzanneti)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-fzanneti-0A66C2?style=flat&logo=linkedin&logoColor=white)](https://linkedin.com/in/fzanneti)