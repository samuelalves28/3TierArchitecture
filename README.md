# Projeto com Arquitetura em 3 Camadas

## Descrição

Este projeto é um exemplo de aplicação utilizando a arquitetura em 3 camadas. A arquitetura em 3 camadas é uma forma de organizar o código de um projeto de software, distribuindo as responsabilidades entre as camadas de Apresentação, Negócio e Dados.

## Estrutura do Projeto

- **Apresentação (API)**: Responsável pela interface com o usuário, seja ela uma interface gráfica, uma API REST, etc.
- **Negócio (Business)**: Contém as regras de negócio e a lógica de aplicação.
- **Dados (Data)**: Gerencia o acesso aos dados, comunicação com bancos de dados, leitura e escrita de arquivos, etc.

## Vantagens

- **Clássica maneira de distribuir responsabilidades**: Separação clara entre apresentação, regras de negócio e acesso a dados.
- **Simplicidade**: Facilita a manutenção e o entendimento do sistema. Nem sempre a complexidade é uma solução para problemas simples.
- **Flexibilidade**: Pode ser aplicada em diversos cenários, sendo especialmente útil em aplicações com foco comercial.

## Implementação no Projeto

Neste projeto, usamos a API para a camada de apresentação dos dados, a camada de negócio foi implementada na camada de `Business`, e a camada de dados foi implementada na camada de `Data`.

## Rodando as Migrations

Para rodar as migrations e atualizar o banco de dados, execute os comandos abaixo:

```bash
cd API
dotnet ef migrations add InitialCreate --startup-project . --project ../Data --context DataBaseContext
dotnet ef database update --startup-project . --project ../Data --context DataBaseContext
