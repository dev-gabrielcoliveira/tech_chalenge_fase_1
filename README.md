# 🎮 Fiap Cloud Games - API (Fase 1)

API REST desenvolvida em .NET 8 para gerenciamento de usuários, com autenticação JWT e controle de acesso por perfis.  
Esta primeira fase do projeto foca no cadastro e autenticação de usuários.

---

## 🚀 Tecnologias utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- JWT Authentication
- Swagger
- Serilog (logs em arquivo)
- NUnit (ou XUnit) para testes unitários

---

## 📌 Funcionalidades (Fase 1)

### 👤 Usuários
- Cadastro de usuários
- Autenticação (login)
- Controle de acesso por perfil (Administrador / Usuário)
- Listagem de usuários

---

## 🔐 Autenticação

A autenticação é feita via JWT.  
Após o login, o sistema retorna um token que deve ser enviado nas requisições protegidas:

---

## 🧠 Regras de negócio

- Usuário deve estar cadastrado para realizar login.
- Senha deve ser válida para autenticação.
- Apenas usuários autenticados podem acessar endpoints protegidos.
- Acesso pode ser restrito por perfil (Admin / Usuário).

---

## 🗄️ Banco de dados

O projeto utiliza **Entity Framework Core** com **Migrations** para criação e versionamento do banco de dados.  
Isso garante que o banco de dados seja criado automaticamente e atualizado com cada nova migração.

---

## 📊 Logs

O sistema utiliza **Serilog** para registro de logs.  
Os logs são salvos em arquivos locais dentro da pasta `logs/`, registrando ações como login, erros e operações importantes.  
Os arquivos de log são criados automaticamente e nomeados por data, como `app-2026-05-03.log`.

---

## 👤 Usuário para testes

Para realizar autenticação, é necessário existir um usuário cadastrado no sistema.  
Esse usuário pode ser criado via endpoint de cadastro ou diretamente no banco de dados.

---

## 📡 Endpoints principais

### Usuários
- `POST /usuarios` - Criar usuário
- `GET /usuarios` - Listar usuários
- `POST /auth` - Login

---

## ⚙️ Como executar o projeto

1. Clonar o repositório
2. Restaurar dependências:  
   `dotnet restore`
3. Executar migrations para configurar o banco:  
   `dotnet ef database update`
4. Rodar o projeto:  
   `dotnet run`

---

## 📖 Swagger

Após iniciar o projeto, acessar:


para visualizar e testar os endpoints disponíveis.

---

## 📌 Observação

Esta é a primeira fase do projeto, focada exclusivamente na gestão de usuários e autenticação.  
As próximas fases irão expandir o sistema para incluir a biblioteca de jogos e outras funcionalidades.

---

## 📋 Testes

### Testes unitários

O projeto possui testes automatizados para validar regras de negócio e endpoints principais.  
Para rodar os testes, use o seguinte comando:

dotnet test

para cada projeto de teste, rode individualmente:

---

## ⚠️ Observações finais

- Este projeto está em sua primeira fase e foi desenvolvido para ser uma base para futuras implementações.
- Caso haja problemas com autenticação ou não consiga rodar o projeto, verifique a configuração de banco de dados ou as migrations aplicadas.