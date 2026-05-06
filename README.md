# Tech Challenge - FIAP Cloud Games
FIAP Cloud Games será uma plataforma de venda de jogos digitais e gestão de servidores para partidas online. Nesta primeira fase foi desenvolvida uma **API REST** em **.NET 8** para o gerenciamento usuários, jogos, biblioteca e promoções

# Funcionalidades
👤 **Usuários**
- Cadastro de usuário
- Listagem de usuários
- Autenticação com JWT
- Diferentes níveis de acesso (Usuário e Administrador)
  
🎮 **Jogos**
- Cadastro de jogos (Admin)
- Listagem de jogos

 📚 **Biblioteca**
- Adicionar jogos à biblioteca do usuário
- Listagem de jogos na biblioteca do usuário
  
💸 **Promoções**
- Criação de promoções (Admin)

# Tecnologias e Padrões de Projeto

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


