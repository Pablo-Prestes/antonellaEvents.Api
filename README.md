# Antonella Events Api

Este projeto foi desenvolvido para testar alguns conhecimentos em tempo livre utilizando(Finalização será demorada.) **.NET 8**, **MySql**, **RabbitMq**, além de diversas bibliotecas para auxiliar na criação, validação, migração e testes da aplicação.
---
## O projeto irá conter as seguintes funcionalidades

- **Cadastrar um evento**
- **Associar usuários - Com e sem conta no sistema**
- **Revogar acesso aos usuários**
- **Notificar via e-mail 2 e 1 dia antes do evento com as confirmações**
- **Confirmação de presença no evento**
- **Validação para evento para não se cadastrar em mais de um no mesmo horário**
- **Eventos podem ser gratuitos ou pagos (Api de teste free stripe, mercado pago)**
- **Tipos de acesso Master, Gerentes de eventos, UsuarioComum**
- **Cancelar evento (Notificar a todos que foram pago que foi cancelado e realizar estorno, caso evento seja pago)**
- **Taxa de cancelamento caso seja cancelado com menos de 1 dia de antecedencia**
---

## Principais tecnlogias
1. **FrameWorks**:
  - Microsoft.EntityFrameworkCore
  - Pomelo.EntityFrameworkCore.MySql
  - MediatR  
  - AutoMapper 
  - RabbitMQ.Client
  - Swashbuckle.AspNetCore.Swagger
  - Microsoft.AspNetCore.Identity.EntityFrameworkCore
  - MassTransit.RabbitMQ 
  - xunit  
  - Moq

2. **Conceitos**:
  - Clean Architeture
  - Docker
  - Solid
  - Clean Code
  - Princípios de DDD
  - CQRS (Read e Write context)
