# Tarefa 7 - Provação 📝

- Documente a sua API usando comentarios no Controller.
- Para adicionar o suporte a documentação adicione o código:

No arquivo '.csproj' dentro da tag: 'PropertyGroup', adicione:
```csharp
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
```

E no arquivo Startup.cs, nessa parte do código:

```csharp
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "hello_2", Version = "v1" });
    
    // Adicione aqui
});
services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=myapp.db"));
```

Adicione o código para ler e gerar a documentação
```csharp
using System;
using System.IO;
using System.Reflection;
```

```csharp
// Set the comments path for the Swagger JSON and UI.
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
c.IncludeXmlComments(xmlPath);
```

- Agora nos arquivos DiretorController.cs e FilmeController.cs adicione os comentarios em cada método.

Exemplo de comentario no metodo Post():
```csharp
    /// <summary>
    /// Cria um diretor
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /diretor
    ///     {
    ///        "nome": "Martin Scorsese",
    ///     }
    ///
    /// </remarks>
    /// <param name="nome">Nome do diretor</param>
    /// <returns>O diretor criado</returns>
    /// <response code="200">Diretor foi criado com sucesso</response>
```
