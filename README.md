# 📌 Priorix API — Gerenciamento Inteligente de Tarefas

A **Priorix API** é um backend completo para gerenciamento de tarefas em um estilo Kanban, com suporte a priorização inteligente via método **RICE**, histórico automático, múltiplos usuários e integração com **IA (Gemini)** para gerar sugestões, melhorias e checklists automáticos.

O projeto segue **Clean Architecture** e utiliza **Entity Framework Core com SQLite** para persistência.

---

# 🚀 Funcionalidades Principais

### ✔ CRUD Completo de Tarefas  
- Criar, editar, excluir e listar tarefas  
- Suporte a descrição, prioridade, comentários e checklist  
- Alteração de status (Kanban)

### ✔ Integração com IA (Gemini)  
O sistema envia o conteúdo da tarefa para a IA, que retorna:  
- Sugestões automáticas  
- Checklists  
- Detalhamento de tarefa  
- Melhorias de texto  

### ✔ Priorização Inteligente — Método RICE  
O backend implementa o cálculo do método **Reach × Impact × Confidence / Effort**, retornando um score para ordenar automaticamente as tarefas.

### ✔ Gestão Completa de Usuários  
- Atribuição de tarefas  
- Usuário responsável  
- Registro de ações

### ✔ Histórico Automático  
Para cada alteração, é registrado:  
- Quem mudou  
- O que mudou  
- Quando alterou  

### ✔ Sistema de Status (Kanban)  
Status padrão:  
- A Fazer  
- Em Progresso  
- Concluído  

O frontend arrasta a tarefa → API atualiza o StatusId.

---

# 🧱 Arquitetura da Aplicação

A API utiliza Clean Architecture com separação completa de responsabilidades:

📁 Priorix.Core
├── Entities (Modelos)
├── Interfaces
│ ├── Services
│ └── Repositories
└── Services (Regras de Negócio)

📁 Priorix.Application
├── DTOs
└── Conversões e validações

📁 Priorix.Data
├── Repositories (EF Core)
├── DataContext (SQLite)
└── DatabaseSeeder

📁 Priorix.Api
├── Controllers (Endpoints REST)
├── Configurações
└── Integração com IA (Gemini)


---

# 📚 Entidades Principais

### **Task**
Representa uma tarefa e contém:
- Título, descrição, data limite  
- Status  
- Usuário responsável  
- IA Suggestion  
- Checklist  
- Comentários  
- Prioridade e etiqueta  
- Histórico  

### **User**
Dados básicos do usuário e permissões.

### **Status**
Define a coluna atual da tarefa (Kanban).

### **TaskHistory**
Registra toda ação feita na tarefa.

### **PriorizationMetrics**
Armazena os valores do método RICE.

---

# 🔌 Endpoints Principais

### ### 📍 **Tarefas (`/api/task`)**

| Método | Rota | Descrição |
|--------|------|-----------|
| GET    | `/api/task` | Lista todas as tarefas |
| GET    | `/api/task/{id}` | Busca uma tarefa específica |
| POST   | `/api/task` | Cria uma nova tarefa |
| PUT    | `/api/task/{id}` | Atualiza uma tarefa existente |
| DELETE | `/api/task/{id}` | Remove uma tarefa |

---

### 📍 **Priorização (`/api/priorization`)**

| Método | Rota | Descrição |
|--------|------|-----------|
| POST | `/api/priorization/rice` | Calcula o score RICE das tarefas |

---

### 📍 **IA / Gemini (`/api/gemini`)**

| Método | Rota | Descrição |
|--------|------|-----------|
| POST | `/api/gemini/generate` | Gera sugestão automática baseada nos dados da tarefa |

---

### 📍 **Usuários (`/api/user`)**

CRUD completo de usuários.

---

### 📍 **Status (`/api/status`)**

Lista e gerencia os status do Kanban.

---

# 🛠 Tecnologias Utilizadas

- **C# .NET 8**
- **ASP.NET Web API**
- **Entity Framework Core**
- **SQLite**
- **Clean Architecture**
- **AI Gemini API**
- **RESTful Endpoints**

---

# 🗄 Banco de Dados

Utiliza **SQLite**, ideal para projetos acadêmicos, simples de distribuir e leve.

O `DatabaseSeeder` cria dados iniciais como:
- Status padrão
- Usuário default
- Tarefas de exemplo (opcional)

---

# ⚙️ Como Rodar o Projeto

1. Clone o repositório:
```sh
git clone https://github.com/SeuUsuario/Priorix.git

Entre na pasta:
cd Priorix

Restaure os pacotes:
dotnet restore

Rode o projeto:
dotnet run

A API abrirá em:
https://localhost:7178
