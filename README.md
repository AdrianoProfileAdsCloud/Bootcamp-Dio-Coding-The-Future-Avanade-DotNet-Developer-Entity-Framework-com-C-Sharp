# Bootcamp Dio - Coding The Future Avanade .NET Developer - Entity Framework com C#

> ℹ️ **Desafio de projeto**
> <br>
Este Desafio de Projeto tem por finalidade demonstrar a aplicabilidade dos conhecimentos do módulo de API e Entity Framework. Para tal, foi desenvolvido um Sistema Gerenciador de Projetos, me baseei na ideia do "Jira". Claro que só para poder desenvolver uma funcionalidade minimalista do sistema, mas que trouxe para meu desenvolvimento um sentido de uso. 
> O projeto conta com apenas duas Entidades, o Colaborador e as Tarefas, onde, se baseando no contexto do Jira, crio uma funcionalidade que mostra o andamento das atividades do colaborador no decorrer do projeto.
> Muitos dos recursos aqui utilizados não foram expostos nas aulas. Mas, com base no que foi ministrado, foi possível ir mais além em busca de mais conhecimentos.

## 🎯Contexto
Contrução de um Sistema Gerenciador de Projetos, onde você podemos cadastrar um colaborador de um projeto e adicionar ao mesmo uma lista de tarefas que deseverá realizar ao longo do projeto.Onde será possível acompanhar o Status das tarefas associadas ao colaborador.

Tanto os Colaboradores quanto a lista de Tarefas conta com um CRUD, ou seja, é possivél ter as aperações comuns em um Sistema como: Pesquisar,Criar,Deletar e Atualizar os registros.

Aplicação com implementação do tipo Web API.

Diagrama do modelo conceitual :

![Diagrama do modelo Conceitual](https://github.com/AdrianoProfileAdsCloud/Bootcamp-Dio-Coding-The-Future-Avanade-DotNet-Developer-Entity-Framework-com-C-Sharp/blob/main/Imagens/Diagrama%20do%20modelo%20conceitual%20.png)

* As tabelas sao descritas conforme a seguir:

- [X] **Tarefa**

Tabela responsável por armazenar informações das Tarefas.<br>
Propriedades: Cada propriedade da classe Tarefa corresponde a uma coluna na tabela do banco de dados.<br>
**Id**: Identificador único da tarefa.<br>
**Titulo**: Título da tarefa.<br>
**Descricao**: Descrição detalhada da tarefa.<br>
**Data**: Data da tarefa.<br>
**Status**: Status da tarefa, utilizando um enum EnumStatusTarefa.<br>
**ColaboradorId**: Chave estrangeira que referencia um colaborador.<br>
**Colaborador**: Propriedade de navegação para acessar o colaborador relacionado.<br>

- [X] **Colaboradores**

Tabela responsável por armazenar informações dos Colaboradores.<br>
Propriedades: Cada propriedade da classe Colaboradores corresponde a uma coluna na tabela do banco de dados.<br>
**ColaboradorId**: Identificador único do colaborador.<br>
**Nome**: Nome do colaborador.<br>
**Projeto**: Nome do projeto no qual o colaborador está trabalhando.<br>
**InicioProjeto**: Data de início do projeto.<br>
**FimProjeto**: Data de término do projeto (pode ser nula).<br>
**Tarefas**: Lista de tarefas atribuídas ao colaborador (propriedade de navegação).<br>

> [!IMPORTANT]
A seguir algumas Configurações e Classes importantes que merecem atenção.

O **DbContext**
onde é feito todo gerenciamento das entidades e o mapeamento para o banco de dados.Nesta classe onde se encontra o Relacionamento da Entidade Colaborador com Tarefas, dizemos nela como o ORM deverá fazer sua implementação no Banco de Dados.

A Propriedade **appsettings.Development** ,  em formato Json consta propriedades que realizam a conexão de fato com o Banco de Dados.Neste caso por se tratar de um projeto para fins academicos foi configurado em Development para em sisema em produção as configurações devem ser realizadas em **appsettings*

###  Pré-requisitos<a id="pre-requisitos"></a>

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:<br>
 [Git](https://git-scm.com/)<br>
 [Docker](https://www.docker.com/products/docker-desktop/)<br>
 [Vs Code](https://code.visualstudio.com/)<br>
 [Dot Net 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)<br>
  Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/)
 
 Este é instalado uma unica vez na máquina e de uso Global:
dotnet tool install --global dotnet-ef  

 



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
