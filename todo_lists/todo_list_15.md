# 📝 TODO-list 15

## Melhorando o código
No arquivo FilmeController.cs no metodo Put alterar o seguinte.
Antes:
```csharp
public async Task<ActionResult<FilmeOutputPutDTO>> Put(long id, [FromBody] FilmeInputPutDTO inputDTO) {
    var filme = new Filme(inputDTO.Titulo, inputDTO.DiretorId);

    await _filmeService.Atualiza(filme, filme.Id);

    var outputDTO = new FilmeOutputPutDTO(filme.Id, filme.Titulo);
    return Ok(outputDTO);
}
```

Depois:
```csharp
public async Task<ActionResult<FilmeOutputPutDTO>> Put(long id, [FromBody] FilmeInputPutDTO inputDTO) {
    var filme = new Filme(inputDTO.Titulo, inputDTO.DiretorId);

    var filmeModificado = await _filmeService.Atualiza(filme, id);

    var outputDTO = new FilmeOutputPutDTO(filmeModificado.Id, filmeModificado.Titulo);
    return Ok(outputDTO);
}
```
Adicionamos a variável filmeModificado, para deixar o codigo mais claro.

Remover a propriedade Id do FilmeInputPutDTO, para evitar confusão:
Antes:
```csharp
public class FilmeInputPutDTO {
    public long Id { get; set; }
    public string Titulo { get; set; }
    public long DiretorId { get; set; }
    public FilmeInputPutDTO(long id, string titulo, long diretorId) {
        Id = id;
        Titulo = titulo;
        DiretorId = diretorId;
    }
```

Depois:
```csharp
public class FilmeInputPutDTO {
    public string Titulo { get; set; }
    public long DiretorId { get; set; }
    public FilmeInputPutDTO(string titulo, long diretorId) {
        Titulo = titulo;
        DiretorId = diretorId;
    }
```

## Adicionando validações
No arquivo FilmeService.cs, adiciona uma validação para verificar se o diretor existe antes de tentar 
criar o filme
Antes:
```csharp
public async Task<Filme> Cria(Filme filme) {
    _context.Filmes.Add(filme);                    

    await _context.SaveChangesAsync();
}
```

Depois:
```csharp
public async Task<Filme> Cria(Filme filme) {
    var diretor = _context.Diretores.FirstOrDefault(diretor => diretor.Id == filme.DiretorId);

    if (diretor == null) {
        throw new Exception("Diretor não encontrado!");
    }

    _context.Filmes.Add(filme);                    

    await _context.SaveChangesAsync();
}
```

Ainda no arquivo FilmeService.cs, adicione as seguintes validações
Antes:
```csharp
public async Task<Filme> Atualiza(Filme filme, long id) {
    filme.Id = id;
    _context.Filmes.Update(filme);

    return filme;
}
```

Depois:
```csharp
public async Task<Filme> Atualiza(Filme filme, long id) {
    var diretor = _context.Diretores.FirstOrDefault(diretor => diretor.Id == filme.DiretorId);

    if (diretor == null) {
        throw new Exception("Diretor não encontrado!");
    }

    var filmeNoDb = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

    if (filmeNoDb == null) {
        throw new Exception("Filme não encontrado!");
    }

    filmeNoDb.Titulo = filme.Titulo;
    filmeNoDb.DiretorId = filme.DiretorId;

    _context.Filmes.Update(filmeNoDb);
    await _context.SaveChangesAsync();

    return filmeNoDb;
}
```