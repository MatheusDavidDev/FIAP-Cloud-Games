# Tech Challenge - FIAP Cloud Games
FIAP Cloud Games é uma plataforma de venda de jogos digitais e gestão de servidores para partidas online.

Nesta primeira fase, foi desenvolvida uma **API REST** em **.NET 8** responsável pelo gerenciamento de usuários, jogos, biblioteca e promoções.

## 🚀 Funcionalidades
**👤 Usuários**
- Cadastro de usuário
- Listagem de usuários
- Autenticação com JWT
- Diferentes níveis de acesso (Usuário e Administrador)
  
**🎮 Jogos**
- Cadastro de jogos (Admin)
- Listagem de jogos

**📚 Biblioteca**
- Adicionar jogos à biblioteca do usuário
- Listagem de jogos na biblioteca do usuário
  
**💸 Promoções**
- Criação de promoções (Admin)

## 🛠️ Tecnologias e Padrões de Projeto

**Tecnologias utilizadas**

- **.NET 8** (ASP.NET Core)
- **Entity Framework Core** (Manipulação do banco de dados)
- **SQL Server** (Banco de dados relacional)
- **JWT (JSON Web Token)** (Utilizado para autenticação e autorização de usuários)
- **MediatR** (Utilizado para desacoplar componentes)
- **FluentValidation** (Utilizado para validação de dados de entrada)
- **Middleware** (Utilizado para tratamento de erros da aplicação)
- **xUnit + Moq** (Utilizado para realização de testes unitários)
- **Swagger** (Documentação e testes dos endpoints)
- **Docker** (Utilizado para containerização do banco de dados)

**Padrões de Projeto utilizados**

- **DDD** (Organização do sistema baseada no domínio do negócio)
- **CQRS** (Separação entre operações de escrita **(Commands)** e leitura **(Query Services)**)
- **Mediator Pattern (MediatR)** (Desacoplamento entre controllers e lógica do sistema)
- **Repository Pattern** (Abstração do acesso a dados)
- **Unit of Work** (Garantir a consistência nas operações de escrita)

## 🏗️ Estrutura da aplicação

O projeto está organizado em camadas, seguindo princípios de separação de responsabilidades:

**FCG.Api**
- Camada de entrada da aplicação.
  - Responsável por expor os endpoints, receber requisições HTTP e aplicar middlewares.

**FCG.Application**
- Camada de aplicação.
  - Contém Commands e Query Services (CQRS), DTOs e interfaces. Responsável por orquestrar os casos de uso.

**FCG.Core**
- Camada de abstrações e componentes compartilhados.
  - Contém interface do repositório, Unit of Work, behaviors e BaseEntity.

**FCG.Domain**
- Camada de domínio.
  - Contém as entidades e regras de negócio da aplicação.

**FCG.Infra**
- Camada de infraestrutura.
   - Responsável pela persistência de dados, implementação de repositórios, queries e integrações externas.

**FCG.Tests**
- Projeto de testes.
  - Responsável pela validação das regras de negócio através de testes unitários.

## ▶️ Como executar a aplicação
### Pré-requisitos
- .NET 8 SDK instalado
- Docker instalado

### 1. Subir o banco de dados
Na raiz do projeto:
```bash
docker-compose -f Docker/docker-compose.yml up -d
```
### 2. Rodar a API
Na raiz do projeto:
```bash
dotnet run --project ./Api/FCG.Api/FCG.Api.csproj
```
### 3. Acessar a aplicação

Após iniciar o projeto, acesse o Swagger em seu navegador:

https://localhost:{porta}/swagger

> A porta será exibida no terminal ao executar o projeto.

### Observações
- Certifique-se de que o Docker esteja em execução antes de iniciar o banco de dados.
- As migrations são aplicadas automaticamente ao iniciar a aplicação, não é necessário executar comandos de banco manualmente.

