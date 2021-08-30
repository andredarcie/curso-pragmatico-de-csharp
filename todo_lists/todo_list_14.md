# 📝 TODO-list 14
## Arrumando uma quesão de banco de dados
No arquivo DataPagerExtension.cs, remover a linha:
```csharp
var totalItemsCountTask = query.CountAsync(cancellationToken);
```

E a linha 
```csharp
paged.TotalItems = await totalItemsCountTask;
```

No lugar da última linha removida adicionar:
```csharp
paged.TotalItems = query.Count();
```

Esse código especifico gerava um bug no PostgreSQL.

## Mudando de banco de dados

- Remover a referencia para o pacote do Sqlite no arquivo .csproj
```csharp
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="5.0.7" />
```

- Adicionar a referencia para o banco de dados PostgreSQL
```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

- Vai aparecer no arquivo .csproj do projeto
```csharp
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="5.0.7" />
```

- Pagar todas as migrations já geradas, inclusive o arquivo ApplicationDbContextModelSnapshot.cs

- Criar uma nova migration 
```csharp
dotnet ef migrations add InitialCreate
```

- No Arquivo Startup.cs alterar 

de:
```csharp
services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=myapp.db"));
```

para:
```csharp
services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Default")));
```

No arquivo appsettings.Development.json, adicionar:
```json
  "ConnectionStrings": {
    "Default": "Server=localhost; Database=MyDB; Username=postgres; Password=1234;"
  },
```
Essa é a forma que vamos conectar ao banco de dados

## Utilizando o Docker
- Agora finalmente vamos executar o banco de dados, só que utilizando o Docker para facilitar a nossa vida
```
docker run -p 5432:5432 -e POSTGRES_PASSWORD=1234 postgres
```

- Verificar se o container está executando e finalmente rodar:
```
dotnet ef database update
```

- Finalmente executar o projeto e verificar se tudo deu certo
```
dotnet run
```
