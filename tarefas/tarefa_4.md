# Tarefa 4 - A primeira trevessia 🗺️

- Na sua pasta "Controllers", crie um Controller para Filmes com base na do Diretores criado em aula.

- Seu "FilmeController.cs" vai ficar da seguinte forma:

| Verbo        | CRUD | URL           | Descrição  |
| -------------|:-------------: |:-------------:| -----:|
| GET          |   Read             | /filme/id   | Busca um filme por Id |
| GET          |   Read             | /filme      |   Busca todos os filmes |
| POST         |   Create           | /filme      |    Cria um filme |
| PUT          |   Update             | /filme      |    Edita um filme |
| DELETE       |   Delete          | /filme      |    Exclui um filme |

- Como regra de validação, um filme só pode ser criado com um Diretor que já exista no banco de dados, cadastrado previamente.
