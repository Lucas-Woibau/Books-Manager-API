# 📚 Sistema de Gerenciamento de Empréstimos

Este projeto é uma **API RESTful** desenvolvida em **ASP.NET Core** para gerenciar o empréstimo de livros em uma biblioteca.

O sistema permite:

* 📖 **Cadastrar novos empréstimos** de livros.
* 🔍 **Consultar** empréstimos ativos ou finalizados.
* ↩️ **Registrar devoluções** de livros.
* ❌ **Excluir registros** de empréstimos.

A API segue boas práticas de desenvolvimento, utilizando:

* **Entity Framework Core** para persistência de dados.
* **Padrão Repository + Services** para organização da lógica de negócio.
* **ResultViewModel** para padronizar as respostas da API.

O projeto pode ser integrado a qualquer aplicação cliente, como **aplicativos web**, **mobile** ou **desktop**, que necessitem consumir informações sobre o ciclo de empréstimos de livros.
