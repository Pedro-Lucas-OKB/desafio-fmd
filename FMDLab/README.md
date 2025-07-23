# Desafio Técnico F&MD Lab 2025 – API RESTful em .NET Core

Este repositório contém a solução do desafio técnico para a vaga de desenvolvedor C# .NET na F&MD. O objetivo é criar uma API RESTful utilizando .NET Core para gerenciar o evento F&MD Lab 2025, permitindo o cadastro de palestras, participantes e integração com uma API de trivia.

---

## 📋 Descrição do Projeto

A API permite:
- Cadastro e listagem de palestras
- Cadastro, edição, listagem e remoção de participantes (cada participante só pode estar inscrito em uma palestra)
- Integração com a API [Open Trivia DB](https://opentdb.com/api.php?amount=1) para buscar perguntas de trivia a serem respondidas nos intervalos do evento

---

## 🗂️ Modelo de Dados

**Relacionamentos:**
- Cada participante pode estar inscrito em apenas uma palestra.
- Uma palestra pode conter vários participantes.

---

## 🚀 Endpoints Requeridos

| Método | Endpoint                           | Descrição                                |
|--------|------------------------------------|------------------------------------------|
| GET    | `/api/palestras`                   | Listar todas as palestras                |
| POST   | `/api/palestras`                   | Cadastrar uma nova palestra              |
| GET    | `/api/participantes`               | Listar todos os participantes            |
| POST   | `/api/participantes`               | Cadastrar um novo participante           |
| PUT    | `/api/participantes/{participanteId}` | Atualizar um participante            |
| DELETE | `/api/participantes/{participanteId}` | Remover um participante               |
| GET    | `/api/trivia`                      | Buscar pergunta e resposta de trivia     |

---

## 🧩 Integração com Trivia

O endpoint `/api/trivia` realiza uma requisição ao serviço externo [Open Trivia DB](https://opentdb.com/api.php?amount=1) e retorna somente a pergunta e a resposta correta extraídas do retorno da API.

---

## 🛠️ Tecnologias Utilizadas

- [.NET Core](https://dotnet.microsoft.com/)
- C#
- API RESTful
- Integração HTTP com APIs externas
- SQLite

---

## ⚡ Como rodar o projeto

1. Clone este repositório
2. Instale as dependências e configure o banco de dados
3. Execute a aplicação com `dotnet run`
4. Utilize ferramentas como [Postman](https://www.postman.com/) ou [Swagger](https://swagger.io/) para testar os endpoints

---

## 📝 Observações

- Este projeto foi desenvolvido como parte de um desafio técnico para a F&MD e serve como exemplo de implementação de uma API RESTful em .NET.
- Fique à vontade para sugerir melhorias ou abrir issues.