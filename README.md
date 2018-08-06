<img align="right" src="https://github.com/marciovcampos/PainelDeCursos/tree/master/doc/csharp.png"/>

# Painel de Cursos

Painel de Cursos é uma aplicação Web desenvolvida usando ASP.NET Web API.

## Arquitetura

O projeto foi divido em 4 camadas (UI, Camada da Apresentação, Camada de Domínio e a Camada de Dados).

Essa arquitetura foi escolhida para diminuir o acoplamento e aumentar a coesão dos projetos, facilitando a manutenção e a evolução do mesmo.
Um exemplo disso seria a facilidade de trocar a camada de UI de JavaScript para angular, pois não havia necessidade de alterar as outras três camadas.

Foi utilizado o padrão de arquitetura em camadas, jutamente com MVC, injeção de dependêcias e o repository.
No projeto .Net foi utilizado a biblioteca Unity para resolução da injeção de dependências e também a Newtonsoft.JSON para conversão de JSON em objeto.

### UI

A pasta client possui a UI (Interfarce de Usúario). Ela foi construída utilizando HTML5, CSS3, BootStrap 3, JavaScript e JQuery.
Ela é responsavél por exibir as informações aos usúarios e consumir a Web API .Net.

### Camada de Apresentação

Na pasta PainalDeCursos se encontram a Controller e a pasta App_Data.
A pasta App_Data contém o arquivo data.json que é utilizado como nossa base de dados.

### Camada de Dominío

Na pasta PainelDeCursos.Domain se encontram as models do domínio da aplicação e os contratos dos repositórios (As Interfaces).

### Camada de Dados

A pasta PainelDeCurso.Infra.Data é responsável pelo acesso aos dados que são utilizados na aplicação. 

### Exemplo de Arquivo JSON

```JSON
[
     {
        "Id": 5,
        "Status": "Active",
        "Company": "Empresa 10",
        "Name": "Curso 10",
        "Description": "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ultrices mi mauris, varius laoreet risus condimentum vitae. Fusce dictum est tortor",
        "Quantity": 128
    }    
]
````

## Telas
<img align="center" src="https://github.com/marciovcampos/PainelDeCursos/tree/master/doc/01.JPG"/>
<img align="center" src="https://github.com/marciovcampos/PainelDeCursos/tree/master/doc/02.JPG"/>
<img align="center" src="https://github.com/marciovcampos/PainelDeCursos/tree/master/doc/03.JPG"/>
<img align="center" src="https://github.com/marciovcampos/PainelDeCursos/tree/master/doc/04.JPG"/>





