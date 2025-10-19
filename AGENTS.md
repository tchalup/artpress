## 1\. Tecnologias e Frameworks Principais

| Componente | Detalhe |
| :--- | :--- |
| **Framework** | **.NET 8** |
| **Linguagem** | C\# |
| **Tipo de Projeto** | ASP.NET Core Web API |
| **Banco de Dados** | Entity Framework Core 8 |
| **Compatibilidade DB** | PostgreSQL |
| **ORM Abordagem** | Code-First (via EF Core Migrations) |

## 2\. Estrutura da Arquitetura Limpa (Clean Architecture)

O projeto deve ser estritamente dividido em quatro projetos (camadas) dentro da Solution:

| Camada | Projeto | Responsabilidade Principal | Regras de Dependência |
| :--- | :--- | :--- | :--- |
| **Domain** | `[NomeDoProjeto].Domain` | Entidades de Negócio, Enums, Interfaces de Repositório. | **Nenhuma dependência externa.** |
| **Application** | `[NomeDoProjeto].Application` | Lógica de Negócio (Use Cases), DTOs, Validações, Interfaces de Serviços. | Depende de **Domain**. |
| **Infrastructure** | `[NomeDoProjeto].Infrastructure` | Implementação de Repositórios (EF Core), Configuração de DB Context, Implementação de Serviços Externos (Email, Logging, etc.). | Depende de **Domain** e **Application**. |
| **API** | `[NomeDoProjeto].API` | Controllers, Configuração (DI, Autenticação), Middlewares, Ponto de Entrada. | Depende de **Application** e **Infrastructure**. |

## 3\. Padrões de Domínio e Banco de Dados

### Entity Framework Core

  * **ORM:** EF Core 8 com abordagem Code-First.
  * **Migrations:** Utilize o EF Core Migrations para gerenciar o versionamento do esquema do banco de dados. Crie novas Migrations sempre que o modelo do `Domain` for alterado.

### Propriedades Padrões para Entidades

Todas as entidades de domínio devem herdar estas propriedades (sugere-se uma classe base, como `BaseEntity`):

```csharp
public abstract class BaseEntity
{
    public Guid Id { get; set; } // Chave Primária
    public DateTime DataCriacao { get; set; } // Obrigatório
    public DateTime? DataAtualizacao { get; set; } // Opcional (Nullable)
}
```

## 4\. Padrões da API (API Layer)

  * **Estilo:** Todos os endpoints devem aderir aos padrões **RESTful** (uso correto de verbos HTTP - GET, POST, PUT, DELETE - e códigos de status).
  * **Segurança (Obrigatório):** Todos os endpoints protegidos devem exigir um token **JWT** (JSON Web Token) válido no cabeçalho `Authorization: Bearer <token>`. A configuração de autenticação JWT deve ser feita no projeto **API**.
  * **Endpoints:** Priorize o uso de `[ApiController]` e atributos de rota (ex: `[Route("api/[controller]")]`).

## 5\. Padrões de Código e Boas Práticas

| Padrão | Requisito de Implementação |
| :--- | :--- |
| **Programação Assíncrona** | Utilize `async/await` em **todas** as operações de I/O (Database, chamadas HTTP, etc.) para garantir escalabilidade e não bloqueio de threads. |
| **Injeção de Dependência (DI)** | Use o container de DI **nativo** do ASP.NET Core. Todas as dependências (Repos, Services) devem ser registradas na inicialização do projeto **API**. |
| **Data Transfer Objects (DTOs)** | **Não exponha entidades de domínio** nos Controllers da API. Use DTOs específicos (`CreateRequest`, `UpdateCommand`, `Response`) na camada **Application** para comunicação. |
| **Validação** | Implemente validações para todos os DTOs de entrada usando a biblioteca **FluentValidation**. Se a validação falhar, retorne o status **400 Bad Request** com uma lista clara de erros. |
| **Tratamento de Erros** | Implemente um **Middleware de Tratamento de Exceções Global** para capturar exceções não tratadas e retornar uma resposta JSON padronizada com o status **500 Internal Server Error**. |

## 6\. Documentação e Logging

  * **Swagger (OpenAPI):** O projeto **API** deve estar configurado com Swagger/OpenAPI. O Swagger deve permitir a **execução de testes** e a **inserção do token JWT** para endpoints protegidos.
  * **Logging:** Utilize a biblioteca **Serilog** para logging estruturado.
      * Desenvolvimento: Logs devem ser exibidos no console.
      * Ambiente de Produção: Prepare a configuração para integração futura com **Elasticsearch/Seq**.

## 7\. Testes

Projetos de teste devem ser criados e mantidos:

  * **Testes Unitários:** Projeto usando **xUnit** para testar as lógicas nas camadas **Domain** e **Application**.
  * **Testes de Integração:** Projeto opcional para testes de ponta a ponta na camada **API** (testando Controllers, DI e acesso simulado/real ao DB).

## 8\. Containerização (Docker)

  * **Dockerfile:** Deve haver um `Dockerfile` funcional na raiz do projeto **API** para criar a imagem Docker da aplicação.
  * **Docker Compose:** Crie e **mantenha atualizado** o arquivo `docker-compose.yml` para orquestrar a aplicação (API) e o banco de dados (PostgreSQL).

-----

**Instrução para Jules:** **Ao receber uma tarefa, sempre consulte este `AGENTS.md` para garantir que o código, a estrutura e as práticas adotadas estejam em conformidade com a arquitetura limpa e os padrões de tecnologia .NET 8 estabelecidos.**