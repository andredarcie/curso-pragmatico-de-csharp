# 📝 TODO-list 2

- Criar um Model para Movie
- Adicionar Db Context no projeto e configurar como service
- Adicionar o pacote Entity Framework, para trabalhar com banco de dados SQLite
```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

- Adicionar o pacote do Entity Framework para ferramentas como gerador de migrations
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

- Adicionar ef como global para execução dos seus comandos
```
dotnet tool install --global dotnet-ef
```

- Adicionar a primeira migration do projeto
```
dotnet ef migrations add InitialCreate
```

- Atualizar/criar o banco de dados
```
dotnet ef database update
```

- Adicionar o CRUD de Movies no Controller
- Adicionar os blocos de try catch