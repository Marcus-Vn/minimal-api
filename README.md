# Minimal API

![.NET](https://img.shields.io/badge/.NET-9-informational?logo=dotnet)
![Tests](https://img.shields.io/badge/tests-passing-brightgreen)
![License](https://img.shields.io/github/license/Marcus-Vn/minimal-api)

Projeto **Minimal API** em .NET 9, com endpoints para gerenciar **administradores** e **veículos**, autenticação via **JWT** e documentação via **Swagger**.

---

## Tecnologias

- .NET 9 / ASP.NET Core Minimal API  
- JWT (JSON Web Tokens)  
- Swagger para documentação  
- Entity Framework Core (DbContexto configurado)  
- DotNetEnv para variáveis de ambiente  
- MSTest para testes

---

## Endpoints

### Home
- `GET /` – Retorna informações básicas da API.

### Administradores
- `POST /administradores/login` – Login, retorna token JWT.  
- `GET /administradores` – Lista administradores (**role: Adm**).  
- `GET /administradores/{id}` – Busca por ID (**role: Adm**).  
- `POST /administradores` – Cria novo administrador (**role: Adm**).

### Veículos
- `POST /veiculos` – Cria veículo (**roles: Adm, Editor**).  
- `GET /veiculos` – Lista veículos (**autenticado**).  
- `GET /veiculos/{id}` – Busca por ID (**roles: Adm, Editor**).  
- `PUT /veiculos/{id}` – Atualiza veículo (**role: Adm**).  
- `DELETE /veiculos/{id}` – Remove veículo (**role: Adm**).

---
