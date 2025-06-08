# SafeRoute

## Descrição do Projeto

O **SafeRoute** é uma API desenvolvida em .NET 8 para gerenciamento de rotas seguras, eventos climáticos e recursos de abrigo em situações de emergência. O sistema permite o cadastro, consulta, atualização e remoção de usuários, eventos climáticos e abrigos, além de oferecer recursos de análise de sentimento em relatos de usuários utilizando ML.NET. O objetivo é fornecer informações rápidas e confiáveis para tomada de decisão em situações críticas, promovendo segurança e eficiência no atendimento à população.

---

## Tecnologias Utilizadas

- **.NET 8**
- **C# 12**
- **Entity Framework Core**
- **AutoMapper**
- **ML.NET** (para análise de sentimento)
- **Swagger / Swashbuckle** (documentação automática)
- **xUnit** (testes unitários)
- **Moq** (mocking em testes)
- **Microsoft.EntityFrameworkCore.InMemory** (banco em memória para testes)

---

## Como Executar o Projeto

### 1. Pré-requisitos

- .NET 8 SDK instalado
- Visual Studio 2022 ou superior

### 2. Configuração

Clone o repositório:

```bash
git clone https://github.com/seu-usuario/safe-route.git
cd safe-route
```

> **Nota:** O projeto já está configurado para utilizar um banco de dados na nuvem Azure. Não é necessário configurar nada adicional para o banco de dados.

### 3. Restaurar pacotes e compilar

```bash
dotnet restore
dotnet build
```

### 4. Executar a aplicação

```bash
dotnet run
```

A API estará disponível em:  
https://localhost:7117

### 5. Acessar a documentação Swagger

Navegue até:  
https://localhost:7117/swagger  
para visualizar e testar os endpoints.

---

## Documentação dos Endpoints

### Usuários

- **POST** `/api/User` — Cadastra um novo usuário.
- **GET** `/api/User` — Lista todos os usuários.
- **GET** `/api/User/{cpf}` — Busca usuário pelo CPF.
- **PUT** `/api/User/{cpf}` — Atualiza usuário pelo CPF.
- **DELETE** `/api/User/{cpf}` — Remove usuário pelo CPF.

### Eventos Climáticos

- **POST** `/api/ClimaticEvent` — Cadastra um novo evento climático.
- **GET** `/api/ClimaticEvent` — Lista todos os eventos.
- **GET** `/api/ClimaticEvent/{eventCode}` — Busca evento pelo código.
- **PUT** `/api/ClimaticEvent/{eventCode}` — Atualiza evento pelo código.
- **DELETE** `/api/ClimaticEvent/{eventCode}` — Remove evento pelo código.

### Recursos Seguros (Abrigos)

- **POST** `/api/SafeResource` — Cadastra um novo recurso seguro.
- **GET** `/api/SafeResource` — Lista todos os recursos.
- **GET** `/api/SafeResource/{resourceCode}` — Busca recurso pelo código.
- **PUT** `/api/SafeResource/{resourceCode}` — Atualiza recurso pelo código.
- **DELETE** `/api/SafeResource/{resourceCode}` — Remove recurso pelo código.

### Análise de Sentimento

- **POST** `/api/Sentiment/analyze` — Recebe um relato textual e retorna o sentimento (positivo/negativo).

**Exemplo de JSON:**

```json
{
    "text": "O abrigo foi muito útil e bem organizado."
}
```

---

## Instruções de Testes

### 1. Testes Unitários

Os testes estão localizados no projeto `SafeRoute.Tests`.

Para rodar os testes:

```bash
dotnet test
```

Os testes cobrem os principais fluxos dos repositórios, incluindo operações de CRUD e validações.

### 2. Testes de Endpoints

Utilize o Swagger (`/swagger`) para testar manualmente os endpoints.

**Exemplo de JSON para criar um recurso seguro:**

```json
{
    "resourceCode": "RES001",
    "name": "Abrigo Central",
    "description": "Abrigo principal da cidade",
    "latitude": -23.5,
    "longitude": -46.6,
    "capacity": 200
}
```

### 3. Testes de Análise de Sentimento

Envie um POST para `/api/Sentiment/analyze` com o texto do feedback.

O retorno indicará se o sentimento é positivo ou negativo.
