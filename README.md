# 🚗 Oficina de Automóveis - API REST em .NET 9

Este repositório contém o desenvolvimento de uma API RESTful para o sistema de gerenciamento de uma oficina de automóveis. A aplicação foi construída em **.NET 9** com **SQL Server** como banco de dados relacional, seguindo boas práticas de arquitetura e organização de código.

## 📌 Objetivo do Projeto

Facilitar o controle das operações da oficina, como:

- Cadastro de clientes e veículos
- Agendamento de reparações
- Registro de pagamentos
- Controle de funcionários
- Gestão de permissões de acesso

## 🛠️ Tecnologias Utilizadas

- ✅ ASP.NET Core 9 (Web API)
- ✅ C#
- ✅ SQL Server
- ✅ Entity Framework Core
- ✅ Visual Studio 2022
- ✅ Swagger (para documentação da API)

## 🧩 Estrutura do Banco de Dados

O banco de dados se chama `OficinaDeAutomoveis` e possui as seguintes tabelas principais:

- `Clientes`
- `Veiculos`
- `Funcionarios`
- `Agendamentos`
- `Pagamentos`
- `Reparacoes`
- `Permissoes`
- `Usuarios` (com controle de autenticação e autorização)

> Os relacionamentos entre as entidades seguem as regras de integridade referencial, utilizando **chaves estrangeiras**.

## 🔌 Endpoints da API

A API oferece endpoints RESTful para as principais operações CRUD. A documentação completa dos endpoints pode ser acessada via Swagger:


Exemplos de rotas:

- `GET /api/clientes`
- `POST /api/veiculos`
- `PUT /api/reparacoes/{id}`
- `DELETE /api/pagamentos/{id}`

## 🧪 Como Executar o Projeto

1. Clone o repositório:
git clone https://github.com/anajulialeite/API_Oficina_Mecanica.git

Execute as migrações do Entity Framework:
dotnet ef database update
dotnet run
https://localhost:5059/swagger

## 🚀 Funcionalidades Futuras

Autenticação via JWT

Controle de acesso por nível de permissão

Dashboard com estatísticas de serviços realizados

Integração com serviços de envio de notificações

## 👩‍💻 Desenvolvedora

Feito com dedicação por Ana Júlia

    "A perfeição está nos detalhes, e a persistência é o combustível para alcançá-la." – Ana Júlia

# license

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](./LICENSE)
