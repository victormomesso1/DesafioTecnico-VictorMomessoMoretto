**Programa em C# para Obter Dados Aleatórios de Usuários com Conexão no Banco de Dados (PostgreSQL). Neste repositório possui o Desafio VB6 na pasta "DesafioVB6".**


**Funcionalidades principais:**

•  Obtém dados de usuários aleatórios da API "Random User Generator".

•  Código dividido em diversas estruturas para melhor organização da arquitetura.

•  Desenvolvimento de API com método GET para gerar relatórios de todos os usuários no front-end.

•  Conecta-se a um banco de dados PostgreSQL.

•  Insere os dados dos Usuários Aleatórios no PostgreSQL.

•  Imprime LOG para cada consulta API.

•  Gera Token JWT.

•  Utilização de DTOs (Data Transfer Objects).

•  Pasta com materiais extras como modelagem do banco de dados, front end, e documentação da API.

•  Materiais Extras: Pasta com arquivo PDF da Modelagem do Banco de Dados, Front-End em arquivo HTML( css e JS estão inbutidos nele) e Documentação API.



**Estrutura do Código:**


• **Controllers:** Responsáveis pelos endpoints da aplicação. Aqui estão as APIs que recebem as requisições HTTP e direcionam para o serviço adequado.

• **Models:** Contém as classes de modelo de dados que representam a estrutura dos dados que a aplicação manipula e trafega.

• **DTOs (Data Transfer Objects):** Utilizados para transferir dados entre diferentes camadas da aplicação.

• **Repositories:** Contêm todas as operações com o banco de dados, acessando, armazenando e modificando os dados conforme necessário.

• **Services:** Contêm a lógica de negócio e interagem com os repositórios para realizar as operações necessárias. Nesta aplicação, os serviços são considerados a "regra de negócio".

• **Context:** Dedicado à configuração do banco de dados, definindo como as entidades e suas relações são mapeadas para o banco.

• **Properties:** Arquivos de configuração de inicialização, determinando as configurações usadas quando a aplicação é executada.


**Bibliotecas Utilizadas:**


• **Npgsql:** Provedor de dados .NET para PostgreSQL que permite conectar-se ao banco de dados, executar consultas SQL e manipular dados.

• **Newtonsoft.Json:** Serializar e desserializar dados JSON, permitindo converter objetos em JSON.

• **NLOG:** Biblioteca de logging para .NET, usada para registrar logs detalhados das operações da aplicação.

• **Microsoft.AspNetCore.Authentication.JwtBearer:** Middleware de autenticação JWT.

• **Substituição da biblioteca AutoMapper:** Utilizei Conversores Implícitos para realizar conversão entre entidades e DTOs de forma simples e direta(implicit operator).


