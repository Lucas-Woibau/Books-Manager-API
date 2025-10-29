# 📚 Gerenciador de Biblioteca – API em .NET 9

> 🚀 Projeto desenvolvido como **desafio técnico** proposto pela plataforma **Next Wave**, com foco em boas práticas, arquitetura limpa e aplicação de conceitos avançados em desenvolvimento de APIs RESTful.

---

## 🎯 Objetivo

O projeto tem como objetivo **demonstrar a aplicação prática de conceitos avançados no desenvolvimento de APIs** dentro de um sistema de gerenciamento de biblioteca.

Ele foi construído para servir como **base de estudos** e **referência em arquitetura limpa e boas práticas** de desenvolvimento em **.NET**.

---

## 🧠 Conceitos aplicados

* 🏛️ **Domain-Driven Design (DDD)** → estruturação do domínio de forma clara e orientada a regras de negócio.  
* 🧩 **Princípios SOLID** → código limpo, coeso e de fácil manutenção.  
* 🗂️ **Separação de camadas (Clean Architecture)** → `Core`, `Application`, `Infrastructure`, `API`.  
* ⚙️ **Padrões de projeto** → uso de *Services*, *ViewModels*, *InputModels* e *Result Pattern* para padronizar operações.  
* 🌐 **RESTful API** → endpoints padronizados (GET, POST, PUT, DELETE).  
* ✅ **Validação e tratamento de erros** → respostas consistentes e seguras.  
* 💾 **Persistência com Entity Framework Core** → uso de *migrations* e integração com SQL Server.  
* 🧪 **Testabilidade** → arquitetura que facilita a criação de testes unitários e de integração.  

---

## ⚡ Funcionalidades

O sistema permite:

📘 **Gerenciamento de livros**
- Cadastrar, consultar, atualizar e excluir livros.  
- Controle de status (disponível / indisponível).  
- Validação de dados.  

👤 **Gerenciamento de usuários**
- Cadastro e consulta de usuários.  

📅 **Empréstimos e devoluções**
- Registrar empréstimos e definir datas de devolução.  
- Atualizar status do livro automaticamente.  
- Exibir mensagens de atraso ou devolução no prazo.  

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Finalidade |
|-------------|-------------|
| **.NET 9** | Plataforma principal da aplicação |
| **C#** | Linguagem de programação |
| **Entity Framework Core** | ORM para persistência de dados |
| **SQL Server** | Banco de dados relacional |
| **ASP.NET Core Web API** | Criação dos endpoints REST |
| **FluentValidation (opcional)** | Validação de dados de entrada |
| **Swagger** | Documentação e testes de endpoints |

