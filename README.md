# 📦 Meu CRUD API

Projeto de estudo para pratica de backend com front. API RESTful com CRUD de produtos.

## 🚀 Tecnologias
- C# / .NET 10
- Entity Framework Core
- SQLite
- Swagger
- HTML/JavaScript (front-end simples)

## 📋 Funcionalidades
- ✅ Criar produto
- ✅ Listar produtos
- ✅ Editar produto
- ✅ Excluir produto

## 🏃 Como executar
1. Clone o repositório
2. `dotnet run`
3. Acesse `/swagger` para testar a API
4. Acesse `/` para o front-end

## 📌 Em desenvolvimento...
- [x] Backend completo
- [ ] Front-end (em andamento)


## 🧱 Estrutura básica do projeto

MeuCrudApi
│
├── Controllers
│   └── ProductsController.cs
│
├── Models
│   └── Product.cs
│
├── Data
│   └── AppDbContext.cs
│
├── wwwroot
│   └── index.html
│
└── Program.cs


🧠 Lógica de funcionamento do sistema

API (Application Programming Interface)

Uma API é um conjunto de regras que permite que diferentes sistemas se comuniquem entre si.
No contexto deste projeto, a API expõe endpoints HTTP que permitem que aplicações externas manipulem dados de produtos.

Exemplo:

GET /products
POST /products
PUT /products/{id}
DELETE /products/{id}

C# / .NET 10: Plataforma de desenvolvimento da Microsoft. Essa versão é dita de alta performance, suportando hardware moderno e visa simplificar o desenvolvimento com "aplicativos baseados em arquivos" (scripts).

O .NET tem como componentes principais o CLR (Common Language Runtime), sendo apresentado como um mecanismo de execução, fornecendo serviços de compilação para o Intermediate Language (IL).

CLR (Common Language Runtime): Motor de execução com funcionamento similar a uma máquina virtual, sendo responsável por executar o IL. Após a execução, converte o IL para código nativo usando o compilador JIT. Também faz gerenciamento de memória e gerencia um sistema de segurança, controle de threads e exceções.

Carrega o IL na memória

Gerencia a memória (Garbage Collector)

Cuida da segurança e das exceções

IL (Intermediate Language): Código intermediário gerado pelo compilador. Armazenado em assemblies (.dll ou .exe). Executado pelo CLR, e não diretamente pelo hardware.

JIT (Just-In-Time): É o compilador do CLR que converte o código IL em código de máquina, que será executado pelo hardware. A compilação ocorre durante a execução. Compila métodos apenas quando são chamados pela primeira vez (compilação sob demanda).
Permite otimizações específicas para o processador e sistema operacional (OS).

Entity Framework (EF): Consiste em um ORM (Object-Relational Mapper) da Microsoft para .NET, permitindo que se manipule banco de dados usando objetos C# em vez de SQL. O processo ocorre criando uma camada limpa e portátil para acesso a dados.
Compatível com vários tipos de banco de dados; no sistema em questão, foi escolhido usar o SQLite.