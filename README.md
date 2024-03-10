# GerenciadorTurmas.ApiRestFul

## Pré-requisitos
  . SQL Server: necessário ter o SQL Server instalado e configurado para armazenar e acessar os dados utilizados pelo projeto. Recomenda-se utilizar a versão 22 ou superior.

## Configuração de execução
  . Configure a string de conexão no arquivo `appsettings.json` conforme o exemplo abaixo:
  
```json
{
  "ConnectionStrings": {
    "SqlServer": "Server=192.168.0.1;Database=NomeDataBase;User Id=SA;Password=Pass@word;"
  }
}
```

## Criação da base de dados
  . Na pasta `GerenciadorTurmas.ApiRestFul/Scripts SQL/Create`, existem os scripts SQL para a criação do banco de dados e das tabelas necessárias. Preferencialmente, execute-os na ordem alfabética dos nomes dos arquivos para evitar erros.

## Execução do teste de integração
  . Na pasta `GerenciadorTurmas.ApiRestFul/Scripts SQL/IntegrationTest`, existe existe um scripts SQL para preparação do banco para a execução do testes de integração, o script recria/cria as tabela e as valoriza com o dados utilizado nas difinições do teste

## Remoção da base de dados
  . Na pasta `GerenciadorTurmas.ApiRestFul/Scripts SQL/Drop`, existem os scripts SQL para a remoção do banco de dados e das tabelas necessárias. Preferencialmente, execute-os na ordem alfabética dos nomes dos arquivos para evitar erros.
