## Pré-requisitos

Antes de clonar o repositório, instale:

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (recomendado via [nvm-windows](https://github.com/coreybutler/nvm-windows) ou [nvm](https://github.com/nvm-sh/nvm))
- [PostgreSQL](https://www.postgresql.org/download/) (servidor rodando localmente, porta padrão `5432`)
- Ferramenta de linha de comando do EF Core:

  ```bash
  dotnet tool install --global dotnet-ef
  ```

## 1. Clonar o repositório

```bash
git clone <URL_DO_REPOSITORIO>
cd BooksArchive
```

## 2. Configurar o back-end

### 2.1. Configurar a connection string (User Secrets)

A senha do banco **não** fica no repositório — cada pessoa configura a própria localmente:

```bash
cd BooksArchive.Api
dotnet user-secrets init
dotnet user-secrets set "PostgresSettings:ConnectionString" "Host=localhost;Port=5432;Database=booksarchive;Username=postgres;Password=SUA_SENHA_AQUI"
```

Troque `SUA_SENHA_AQUI` pela senha do seu usuário `postgres` local.

### 2.2. Criar o banco e aplicar as migrations

Volte para a raiz da solution e rode:

```bash
cd ..
dotnet ef database update --project BooksArchive.Infra --startup-project BooksArchive.Api
```

Isso cria o banco `booksarchive` (se ainda não existir) e todas as tabelas automaticamente.

### 2.3. Rodar a API
