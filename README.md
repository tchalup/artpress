# Artpress API

API RESTful para gerenciamento de um sistema genérico, construída com .NET 8 e seguindo os princípios da Clean Architecture.

## Sobre o Projeto

Esta API fornece uma base robusta e escalável para um sistema genérico. Ela inclui funcionalidades de CRUD para usuários e autenticação baseada em JWT. A arquitetura foi projetada para ser modular, testável e de fácil manutenção.

## Tecnologias Utilizadas

- **.NET 8**: Framework para construção da aplicação.
- **ASP.NET Core 8**: Para a criação da API RESTful.
- **Entity Framework Core 8**: ORM para interação com o banco de dados.
- **PostgreSQL**: Banco de dados relacional.
- **JWT (JSON Web Tokens)**: Para autenticação e autorização, incluindo refresh tokens.
- **Serilog**: Para logging estruturado.
- **Swagger (OpenAPI)**: Para documentação da API.
- **FluentValidation**: Para validação dos DTOs.
- **xUnit**: Para testes unitários.
- **Docker**: Para conteinerização da aplicação.

## Estrutura do Projeto (Clean Architecture)

O projeto está dividido nas seguintes camadas:

- **Domain**: Contém as entidades de negócio e as interfaces de repositório. Não possui dependências externas.
- **Application**: Contém a lógica de negócio, DTOs, validações e interfaces de serviços.
- **Infrastructure**: Contém a implementação das interfaces definidas no Domain e Application (repositórios, serviços, etc.).
- **API**: Contém os Controllers, middlewares e a configuração de inicialização do projeto.

## Como Executar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [EF Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (`dotnet tool install --global dotnet-ef`)
- [Docker](https://www.docker.com/products/docker-desktop) (opcional, para execução com contêineres)
- Um servidor PostgreSQL em execução.

### Executando com .NET CLI

1. **Clone o repositório:**
   ```bash
   git clone <url-do-repositorio>
   cd <nome-do-repositorio>
   ```

2. **Configure a Connection String:**
   - Abra o arquivo `src/Artpress.API/appsettings.json`.
   - Altere a `DefaultConnection` para apontar para o seu banco de dados PostgreSQL.

3. **Execute as Migrations:**
   ```bash
   cd src/Artpress.API
   dotnet ef database update
   ```

4. **Execute a aplicação:**
   ```bash
   dotnet run
   ```
   A API estará disponível em `https://localhost:5001` (ou a porta configurada).

### Executando com Docker

1. **Clone o repositório:**
   ```bash
   git clone <url-do-repositorio>
   cd <nome-do-repositorio>
   ```

2. **Suba os contêineres:**
   ```bash
   docker-compose up -d --build
   ```
   A API estará disponível em `http://localhost:8080`. A primeira execução pode levar alguns minutos para construir a imagem da API.

## Endpoints da API

A documentação completa dos endpoints está disponível via Swagger, na rota `/swagger` da API em execução.

### Autenticação

- **`POST /api/auth/login`**: Autentica um usuário e retorna um token JWT e um refresh token.
- **`POST /api/auth/refresh`**: Gera um novo token de acesso a partir de um refresh token.

### Usuários (`/api/users`)

- **`GET /`**: Retorna uma lista paginada de todos os usuários.
  - **Query Parameters**:
    - `pageNumber` (int, opcional, default: 1): O número da página.
    - `pageSize` (int, opcional, default: 10, max: 100): O número de itens por página.
  - **Exemplo**: `GET /api/users?pageNumber=2&pageSize=20`

- **`GET /{id}`**: Retorna um usuário específico.
- **`POST /`**: Cria um novo usuário.
- **`PUT /{id}`**: Atualiza um usuário existente.
- **`DELETE /{id}`**: Exclui um usuário.

**Observação**: Todos os endpoints de `/api/users` exigem um token JWT válido no cabeçalho `Authorization` como `Bearer <token>`.

---
Feito com ❤️ por Jules.
