# Trabalho State API

## 🚀 Começando

Configuração do Projeto

Clonar o Repositório
Clone o repositório para sua máquina local usando o Git: bash git clone https://github.com/JoaoNeto132/Trabalho-Jef-State.git
Configurar a String de Conexão Abra o arquivo appsettings.json e configure a string de conexão para o PostgreSQL em ConnectionStrings.DefaultConnection. Substitua as partes Host, Database, Username e Password com as informações do seu servidor PostgreSQL:
json { "ConnectionStrings": { "DefaultConnection": "Host=localhost;Database=TaskDb;Username=seu-usuario;Password=sua-senha" } }

### 📋 Pré-requisitos

Ter o Visual Studio baixado com versão 7.0 do .NET para não haver erros.
Baixar as ferramentas do Pacote Nuget:
Microsoft.AspNetCore.OpenApi Versão 7.0
Microsoft.EntityFrameworkCore Versão 7.0
Microsoft.EntityFrameworkCore.Tools Versão 7.0
Npgsql Versão 7.0
Npgsql.EntityFrameworkCore.PostgreSQL Versão 7.0
Swashbuckle.AspNetCore Versão mais atual

## ✒️ Autor

* **João Pereira Neto** - [João Pereira Neto](https://github.com/JoaoNeto132)
