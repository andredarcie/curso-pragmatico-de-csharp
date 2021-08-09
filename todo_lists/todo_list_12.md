# 📝 TODO-list 12

- Na pasta raiz do seu projeto crie uma nova pasta e coloque seu projeto e outra pasta para o projeto de testes
- Dentro da pasta criada para o projeto de teste execute o comando
```
dotnet new xunit
```
- Crie um teste simples
```csharp
    [Fact]
    public void PassingTest()
    {
        Assert.Equal(4, Add(2, 2));
    }

    int Add(int x, int y)
    {
        return x + y;
    }
```
- Execute o projeto de testes
```
dotnet test
```
- Volte na raiz do projeto execute o seguinte comando, para adicionar a referencia ao outro projeto
```
dotnet add MeuAppTestes/MeusTestesUnitarios.csproj reference MeuApp/MeuApp.csproj
```
- Agora o seu projeto de teste tem uma referencia ao projeto principal
```csharp
  <ItemGroup>
    <ProjectReference Include="..\MeuApp\MeuApp.csproj" />
  </ItemGroup>
```
- Crie uma teoria para testar
```csharp
[Theory]
[InlineData(3)]
[InlineData(2)]
[InlineData(1)]
public void MyFirstTheory(int value)
{
    Assert.True(MenorQueQuatro(value));
}

bool MenorQueQuatro(int value)
{
    return value < 4;
}
```