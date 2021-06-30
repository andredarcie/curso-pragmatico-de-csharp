# Tarefa 6 - Aproximação da caverna profunda ⛰️

## 1. Validações
- Crie as validações necessárias
- No GetAll de Diretor e Filme, verificar se algum filme foi encontrado senão retornar a mensagem: "Filmes não encontrados" ou "Diretores não encontrados"
- No GetById, Put e Delete verifique se o Diretor ou o Filme foi encontrado senão retornar a mensagem: "Filme não encontrado" ou "Diretor não encontrado"

## 2. Tratamento de exceções
- Pesquisar sobre qual é a utilidade de try/catch pelo código
- Coloque em todos os métodos um bloco try/catch para tratamento de exceções
```csharp
try
{
 // Código do método aqui
} catch (Exception ex)
{ 
 return Conflict(ex.Message);
}
```
- Investigar se existe uma forma melhor de fazer isso
