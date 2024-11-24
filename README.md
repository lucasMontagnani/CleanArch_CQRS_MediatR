# Base para Web API com ASP.NET Core 8

Este projeto tem como objetivo servir como base e exemplo de uma Web API utilizando o **ASP.NET Core 8**, seguindo o padrão arquitetural **CQRS (Command Query Responsibility Segregation)**, 
com a implementação do padrão comportamental **Mediator** (através da biblioteca **MediatR**) para promover o desacoplamento entre os componentes do sistema. Além disso, adota princípios da **Clean Architecture**, 
com a separação em camadas e organização orientada ao domínio (**DDD**).

## 🛠️ Tecnologias e Padrões Utilizados

- **CQRS (Command Query Responsibility Segregation)**.
- **Mediator** com a biblioteca MediatR.
- **Clean Architecture** com divisão em camadas e princípios de **DDD (Domain-Driven Design)**.
- **Design Patterns**:
  - **Repository**: Para encapsular e desacoplar o acesso aos dados.
  - **Unit of Work**: Para garantir maior consistência transacional.
- **Entity Framework**: Para persistência de dados.
- **Dapper**: Para consultas otimizadas e performáticas.
- **Injeção de Dependência**: Implementação do princípio SOLID de **Inversão de Dependência**.

## ⚙️ Funcionalidades

### Validações
- Validações de comandos são realizadas com o **FluentValidation**, integrado ao **MediatR**, para garantir que as requisições sejam validadas antes de serem processadas pelos handlers.
- Um **Pipeline Behavior** personalizado atua como middleware, interceptando e validando as requisições antes do processamento, otimizando a performance e reduzindo o acoplamento.

### Notificações
- A interface **INotification** do **MediatR** é utilizada para implementar a transmissão de notificações de forma assíncrona.
- Essas notificações permitem a comunicação desacoplada entre componentes da aplicação, contendo informações sobre eventos do sistema ou erros que precisam ser notificados.

