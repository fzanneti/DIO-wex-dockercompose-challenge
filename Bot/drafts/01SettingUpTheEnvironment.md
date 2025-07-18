# 🧱 Preparar o ambiente Linux (dentro da VM no VirtualBox) para teste

![GitHub repo size](https://img.shields.io/github/repo-size/fzanneti/wex-e2e-csharp)
![GitHub forks](https://img.shields.io/github/forks/fzanneti/wex-e2e-csharp?style=social)
![GitHub Repo stars](https://img.shields.io/github/stars/fzanneti/wex-e2e-csharp?style=social)
![Bootcamp](https://img.shields.io/badge/WEX-End--to--End%20Engineering-blueviolet?logo=vercel&logoColor=white)
![Plataforma](https://img.shields.io/badge/Powered%20by-DIO.io-red?logo=data:image/svg+xml;base64,PHN2ZyBmaWxsPSIjZmZmIiB2aWV3Qm94PSIwIDAgMzIgMzIiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PHBhdGggZD0iTTYuNzEgMy4yNWMtMi44OCAxLjQxLTUuMDcgNC4yMy01LjA3IDcuNzYgMCAzLjU4IDIuMjggNi43IDUuMzMgOC4xNSAxLjgzLS42MiAyLjQtMi4yNiAyLjQtMy44MSAwLS4yMy0uMDItLjQ1LS4wNS0uNjZBLjQ0LjQ0IDAgMDExMC4xIDExYy4yNC0uNzUuMTEtMS41My0uMy0yLjIyQzguOTIgNy45NiA3LjMzIDcuNSA1Ljc0IDcuNjZhNS41NSA1LjU1IDAgM)
![Autor](https://img.shields.io/badge/Autor-fzanneti-blue?style=flat-square&logo=github)

---

> Vamos instalar **.NET, Docker, Docker Compose e Git**, para rodar o projeto localmente e com containers.

---

### ✅ 1. Atualizar pacotes

```bash

sudo apt update && sudo apt upgrade -y

```

---

### ✅ 2. Instalar o .NET SDK 8 (para ASP.NET Core)

```bash

# Instala dependências
sudo apt install -y wget apt-transport-https software-properties-common

# Adiciona repositório da Microsoft
wget wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo rm packages-microsoft-prod.deb

# Atualiza os repositórios com o da Microsoft
sudo apt update

# Instala o SDK do .NET 7
sudo apt install -y dotnet-sdk-8.0

## Verificando a instalação
dotnet --info

```

#### ✔️ Verifique se está instalado:

```bash

dotnet --version

```

---

### ✅ 3. Instalar o Docker

```bash

# Remove versões antigas (caso haja)
sudo apt remove docker docker-engine docker.io containerd runc

# Instala dependências
sudo apt install -y ca-certificates curl gnupg

# Cria o diretório para as chaves
sudo install -m 0755 -d /etc/apt/keyrings

# Baixa e adiciona a chave GPG do Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg

# Adiciona o repositório do Docker
echo \
  "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] \
  https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
 
# Atualiza repositórios
sudo apt update

# Instala Docker
sudo apt install -y docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin

```

### ✔️ Verifique se está funcionando:

```bash

sudo docker version

```

---

## ✅ 4. Instalar o Docker Compose (caso precise usar separadamente)

```bash

sudo curl -L "https://github.com/docker/compose/releases/download/v2.27.0/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose
sudo chmod +x /usr/local/bin/docker-compose

```

### ✔️ Verifique:

```bash

docker-compose --version

```

---

## ✅ 5. Instalar o Git

```bash

sudo apt install -y git

```

#### ✔️ Verifique:

```bash

git --version

```

---

### ✅ 6. Permitir usar Docker sem `sudo` (opcional, mas recomendado)

```bash

sudo usermod -aG docker $USER
newgrp docker

```

---

### ✅ 7. Reboot para garantir tudo funcionando:

```bash

sudo reboot

```

---

## 🚦 Depois do reboot:

* Testa com: `dotnet --version`
* Testa com: `docker run hello-world`

Se tudo funcionar, **estamos prontos pra começar o projeto JarbasBot + Apache** na prática.

---

##### ✍️ Criado por: Fabio Zanneti - 🎯 Projeto: WEX - End to End Engineering
[![GitHub](https://img.shields.io/badge/GitHub-fzanneti-181717?style=flat&logo=github)](https://github.com/fzanneti)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-fzanneti-0A66C2?style=flat&logo=linkedin&logoColor=white)](https://linkedin.com/in/fzanneti)