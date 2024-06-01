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

  # :hammer: Preparando o o ambiente.
  <p> Na pasta Banco de Dados encontra-se o arquivo docker-compose.yml resposável por fazer a instalção do Microsoft SQL Server em um container no docker.
     Para isso o docker deve estar instalado na máquina previamente, segue link caso não tenha instalado:</p>
     
[Docker](https://www.docker.com/products/docker-desktop)
                  
   <p> Entre na pasta Banco de Dados onde esta o aqruivo docker-compose.yml, após clonar ou fazer download deste projeto e executar o seguinte comando no terminal:
     <br>
             <div align="center">docker-compose up -d</div>
     <br>
  E container com a instância do SQL será criada e inicada em seguida.</p>
  <p>Para acessar a instância criada,realize o download do SQL Server Management Studio (SSMS)no link abaixo.Após realizar o dwnload e a instalação, abra o  SQL Server Management Studio e preencha os campos como mostra na imagem baixo:Obs: A senha utilizada consta no arquivo de instalação docker-compose.</p>  
<div align="center">
  
[Download SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

<img src="https://github.com/AdrianoProfileAdsCloud/Bootcamp-Dio-Coding-The-Future-Avanade-DotNet-Developer-Banco-de-Dados/blob/main/Imagens/SQL%20Server%20Management.png" width="350">
</div> 
 <p>Pronto ao se concetar com a instância no container docker poderá seguir com os passos seguintes.</p>

  ### 🎲Rodando a Aplicação<a id="rodando"></a>
   
````
# Clone este repositório
 git clone https://github.com/AdrianoProfileAdsCloud/Bootcamp-Dio-Coding-The-Future-Avanade-DotNet-Developer-Entity-Framework-com-C-Sharp
# Acesse a pasta do projeto no terminal
 cd pasta

# Abra a pasta do projeto no VS Code. Em seguida instale os seguites pacotes, pois alguns são a nível de projeto.
 >  dotnet add package Microsoft.EntityFrameworkCore.Design
 > dotnet add package Microsoft.EntityFrameworkCore.SqlServer
Este último e de nível Global:
 > dotnet tool install --global dotnet-ef
  
 # Comandos para criar as Migrations. Ela gerencia as alterações no esquema do banco de dados ao longo do tempo, de maneira controlada e versionada.
Comando para criar Migration.<br>
 > dotnet-ef migrations add CriacaoDasTabelasDoJira<br>
Apos xecutar este comando usamos o Update para tranasformar esta migartion em uma entidade no Banco de Dodos:<br>
 > dotnet-ef database update

Obs: Antes de executar o último comando "dotnet-ef database update" certifique-se de ter iniciado o container no Docker como mencionado anteriormente, pois este comando criará no SQL o Banco de Dados com as tabelas de acordo com a estrutura das Classes.
 
 # O servidor iniciará na porta:5166
 # Acesse http://localhost:5166/swagger/index.html
 ````

### 🛠 Tecnologias<a id="tecnologias"></a>
 As seguintes ferramentas e tecnologias foram usadas na construção do projeto:
 
  - [C#](https://dotnet.microsoft.com/pt-br/languages/csharp) 
  - [Entity Framework](https://learn.microsoft.com/pt-br/ef/core/)
  - [Sql Server](https://www.microsoft.com/en-gb/sql-server/sql-server-downloads)
  - [Docker](https://www.docker.com/) 

## Metodos
**Swagger**
![Métodos Swagger](https://github.com/AdrianoProfileAdsCloud/Bootcamp-Dio-Coding-The-Future-Avanade-DotNet-Developer-Entity-Framework-com-C-Sharp/blob/main/Imagens/Swagger%20Tarefa.png)

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
  "data": "2024-05-31T07:46:02.258Z",
  "status": 2,
  "colaboradorId":int,
  "colaborador": {
    "id":int,
    "nome": "string",
    "projeto": "string",
    "inicioProjeto": "DateTime",
    "fimProjeto": "DateTime",
    "tarefas": []
  }
}
```

## Metodos
**Swagger**
![Métodos Swagger](https://github.com/AdrianoProfileAdsCloud/Bootcamp-Dio-Coding-The-Future-Avanade-DotNet-Developer-Entity-Framework-com-C-Sharp/blob/main/Imagens/Swagger%20Colaborador.png)

**Endpoints**


| Verbo  | Endpoint                      | Parâmetro | Body               |
|--------|-------------------------------|-----------|--------------------|
| GET    | /Colaborador/{id}             | id        | N/A                |
| PUT    | /Colaborador/{id}             | id        | Schema Colaborador |
| DELETE | /Colaborador/{id}             | id        | N/A                |
| GET    | /Colaborador/ObterTodos       | N/A       | N/A                |
| GET    | /Colaborador/ObterPorNome     | nome      | N/A                |
| GET    | /Colaborador/ObterPorStatus   | status    | N/A                |
| POST   | /Colaborador                  | N/A       | Schema Colaborador |

Esse é o schema (model) de Colaborador, utilizado para passar para os métodos que exigirem

```json
{  
  "nome": "string",
  "projeto": "string",
  "inicioProjeto": "DateTime",
  "fimProjeto": "DateTime",
  "tarefas": []
}
```


## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.
