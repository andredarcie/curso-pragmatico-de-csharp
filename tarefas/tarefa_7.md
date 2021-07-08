# Tarefa 7 - Provação 📝

- Documente a sua API usando comentarios no Controller.
- Para adicionar o suporte a documentação adicione o código:

No arquivo '.csproj' dentro da tag: 'PropertyGroup', adicione:
```csharp
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
```

Agora nos arquivos DiretorController.cs e FilmeController.cs adicione os comentarios em cada método.
Exemplo de comentario no metodo Post().
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
