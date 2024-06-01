# Bootcamp Dio - Coding The Future Avanade .NET Developer - Entity Framework com C#

> ℹ️ **Desafio de projeto**
> <br>
Este Desafio de Projeto tem por finalidade demonstrar a aplicabilidade dos conhecimentos do módulo de API e Entity Framework. Para tal, foi desenvolvido um Sistema Gerenciador de Projetos, me baseei na ideia do "Jira". Claro que só para poder desenvolver uma funcionalidade minimalista do sistema, mas que trouxe para meu desenvolvimento um sentido de uso. 
> O projeto conta com apenas duas Entidades, o Colaborador e as Tarefas, onde, se baseando no contexto do Jira, crio uma funcionalidade que mostra o andamento das atividades do colaborador no decorrer do projeto.
> Muitos dos recursos aqui utilizados não foram expostos nas aulas. Mas, com base no que foi ministrado, foi possível ir mais além em busca de mais conhecimentos.

## 🎯Contexto
Contrução de um Sistema Gerenciador de Projetos, onde você podemos cadastrar um colaborador de um projeto e adicionar ao mesmo uma lista de tarefas que deseverá realizar ao longo do projeto.Onde será possível acompanhar o Status das tarefas associadas ao colaborador.

Tanto os Colaboradores quanto a lista de Tarefas conta com um CRUD, ou seja, é possivél ter as aperações comuns em um Sistema como: Pesquisar,Criar,Deletar e Atualizar os registros.

A sua aplicação deverá ser do tipo Web API ou MVC, fique a vontade para implementar a solução que achar mais adequado.

A sua classe principal, a classe de tarefa, deve ser a seguinte:

![Diagrama da classe Tarefa](diagrama.png)

Não se esqueça de gerar a sua migration para atualização no banco de dados.

## Métodos esperados
É esperado que você crie o seus métodos conforme a seguir:


**Swagger**


![Métodos Swagger](swagger.png)


**Endpoints**


| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| GET    | /Tarefa/{id}            | id        | N/A           |
| PUT    | /Tarefa/{id}            | id        | Schema Tarefa |
| DELETE | /Tarefa/{id}            | id        | N/A           |
| GET    | /Tarefa/ObterTodos      | N/A       | N/A           |
| GET    | /Tarefa/ObterPorTitulo  | titulo    | N/A           |
| GET    | /Tarefa/ObterPorData    | data      | N/A           |
| GET    | /Tarefa/ObterPorStatus  | status    | N/A           |
| POST   | /Tarefa                 | N/A       | Schema Tarefa |

Esse é o schema (model) de Tarefa, utilizado para passar para os métodos que exigirem

```json
{
  "id": 0,
  "titulo": "string",
  "descricao": "string",
  "data": "2022-06-08T01:31:07.056Z",
  "status": "Pendente"
}
```


## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.
