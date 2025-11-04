echo "# 📞 Lista Telefônica API

API desenvolvida em **.NET 8**, utilizando **MongoDB** como banco de dados e **MediatR** para comunicação entre camadas.  
Permite o gerenciamento completo de contatos telefônicos — criar, listar, buscar, atualizar e remover.

---

## 🚀 Tecnologias Utilizadas
- 🟣 **.NET 8 (ASP.NET Core Web API)**
- 🍃 **MongoDB (Driver Oficial)**
- 🔁 **MediatR (CQRS Pattern)**
- 🧱 **Swagger (Documentação interativa)**

---

## 📁 Estrutura do Projeto
\`\`\`
ListaTelefonica.Api/
├── Application/
│   ├── Commands/          → Create, Update, Delete (operações de escrita)
│   ├── Queries/           → GetAll, GetById (operações de leitura)
│   ├── Handlers/          → Manipuladores do MediatR
│
├── Controllers/
│   └── ContatosController.cs → Endpoints REST da API
│
├── Domain/
│   └── Contato.cs → Modelo de dados (Id, Nome, Telefone)
│
├── Services/
│   └── ContatoService.cs → Lógica de acesso ao MongoDB
│
├── appsettings.json → Configurações de conexão com o MongoDB
└── Program.cs → Configuração da aplicação
\`\`\`

---

## ⚙️ Configuração do Banco (MongoDB)
No arquivo \`appsettings.json\`, configure sua conexão MongoDB:

\`\`\`json
{
  \"MongoDb\": {
    \"ConnectionString\": \"mongodb://localhost:27017\",
    \"Database\": \"listaTelefonicaDb\",
    \"Collection\": \"contatos\"
  }
}
\`\`\`

---

## 📡 Endpoints da API (CRUD Completo)
| Método | Rota | Descrição |
|--------|------|------------|
| **POST** | /contatos | ➕ Criar um novo contato |
| **GET** | /contatos | 📋 Listar todos os contatos |
| **GET** | /contatos/{id} | 🔍 Buscar um contato específico |
| **PUT** | /contatos/{id} | ✏️ Atualizar dados de um contato |
| **DELETE** | /contatos/{id} | ❌ Remover um contato da lista |

---

## 🧠 Padrão CQRS + MediatR
Cada operação (ex: \`CreateContato\`, \`UpdateContato\`, \`GetAllContatos\`) é dividida em **Command/Query** + **Handler**:
- Command → representa a ação.
- Handler → executa a lógica via MediatR.
- O Controller apenas envia a requisição para o MediatR.

---

## ▶️ Executando o Projeto
\`\`\`bash
dotnet build
dotnet run
\`\`\`
Swagger disponível em: **http://localhost:xxxx/swagger**

---

## 💾 Exemplo de Contato
\`\`\`json
{
  \"nome\": \"Gustavo Nascimento\",
  \"telefone\": \"(11)97058-2152\"
}
\`\`\`
/*OBRIGADO PELO DESAFIIO!!!*/
---

## 🧑‍💻 Autor
**Gustavo Nascimento**  
[GitHub](https://github.com/GustavoNascimento07) | [LinkedIn](https://linkedin.com/in/GustavoNascimento07)
" > README.md

git add README.md
git commit -m "Adicionando README.md com descrição completa da API"
git push
