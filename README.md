# Fashion Trend
Projeto desenvolvido durante o módulo de Microserviços da ADA.

### Descrição
Este projeto backend é implementado utilizando Clean Architecture. Ele incorpora o uso do banco de dados SQLite para armazenamento de dados, Fluent Validation para validação de requisições, Kafka para mensageria e Twilio para o envio de minutas de contrato.

### Pré-requisitos
Antes de começar, certifique-se de ter instalado em sua máquina:

[Apache Kafka](https://kafka.apache.org/downloads)

### Configuração do Twilio
Para utilizar a funcionalidade de envio de minutas de contrato via Twilio, é necessário configurar suas credenciais no arquivo user_secrets.json da seguinte forma:

{<br>
  "Twilio": {<br>
    "AccountsID": "SuaAccountsIDAqui",<br>
    "AuthToken": "SeuAuthTokenAqui",<br>
    "TwilioPhoneNumber": "SeuNumeroTwilioAqui"<br>
  }<br>
}<br>
