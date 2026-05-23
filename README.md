# microondasApi
Projeto desenvolvido em .NET utilizando WinForms, com foco na simulação de um micro-ondas digital contendo aquecimento manual, programas pré-definidos e cadastro de programas personalizados.

O projeto foi estruturado utilizando separação em camadas e aplicação do padrão CQRS para organização das regras de negócio.

Funcionalidades implementadas
Aquecimento manual
Início rápido (30 segundos / potência 10)
Pausa e cancelamento
Continuação do aquecimento após pausa
Acréscimo de 30 segundos durante aquecimento
Conversão de tempo para formato minuto:segundo
Programas pré-definidos
Cadastro de programas personalizados
Persistência de programas em arquivo JSON
Validações de regras de negócio
Exceptions customizadas
Estrutura preparada para integração com Web API

Microondas.Application
Microondas.Domain
Microondas.Infrastructure
Microondas.WinForms
Microondas.Tests

C#
.NET
WinForms
JSON
CQRS

## Observações

Os programas personalizados são armazenados localmente em arquivo JSON.

Os programas pré-definidos possuem:

potência específica
tempo específico
caractere próprio de aquecimento
instruções de preparo

O caractere "." foi reservado exclusivamente para aquecimento manual.

## Execução

Basta abrir a solução:

MicroondasDigital.sln

e executar o projeto WinForms.

## Próximos passos
Implementação da Web API
Autenticação JWT
Middleware global de exceptions
Logs de erro
Persistência em banco de dados
