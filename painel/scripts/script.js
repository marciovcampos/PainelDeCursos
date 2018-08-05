var tbody = document.querySelector('table tbody');
var curso = {};

carregaCursos();

function Cadastrar(){
            
    curso.empresa = document.querySelector("#empresa").value;
    curso.nome = document.querySelector("#nomeCurso").value;
    curso.descricao = document.querySelector("#descricao").value;
    curso.qtdAlunos = document.querySelector("#qtdAlunos").value;
    
    if (curso.id === undefined || curso.id === 0){
        salvarCursos('POST', 0, curso); 
    }else{
        salvarCursos('PUT', curso.id, curso); 
    }     

    carregaCursos(); 
    $('#myModal').modal('hide');        
}

function carregaCursos(){

    tbody.innerHTML = '';

    var xhr = new XMLHttpRequest();
    
    xhr.open('GET', `http://localhost:62920/api/Curso`, true);

    xhr.onload = function(){
        console.log(this.responseText);      
        var cursos = JSON.parse(this.responseText);
        for(var indice in cursos){
            adicionaLinha(cursos[indice]);
        }      
    }

    xhr.send();
            
}

function salvarCursos(metodo, id, corpo){
    var xhr = new XMLHttpRequest();

    if (id === undefined || id === 0)
        id = '';

    xhr.open(metodo, `http://localhost:62920/api/Curso/${id}`, false);
    
    xhr.setRequestHeader('content-type', 'application/json');
    xhr.send(JSON.stringify(corpo));
            
}   

function excluirCurso(id){

    var xhr = new XMLHttpRequest();

    xhr.open('DELETE', `http://localhost:62920/api/Curso/${id}`, false);
            
    xhr.send();

}

function excluir(id){
    excluirCurso(id);
    carregaCursos();
}

function adicionaLinha(curso){
    
    var trow = `<tr>
                <td>${curso.empresa}</td>
                <td>${curso.nome}</td>
                <td>${curso.descricao}</td>
                <td>${curso.qtdAlunos}</td> 
                <td>
                    <button class="btn btn-info" data-toggle="modal" data-target="#myModal" onclick='editarCurso(${JSON.stringify(curso)})'>Editar</button>             
                    <button class="btn btn-danger" onclick='excluir(${curso.id})'>Excluir</button>
                </td>              
            </tr>`;

    tbody.innerHTML += trow;

}

function editarCurso(_curso){
    var btnSalvar = document.querySelector("#btnSalvar");    
    var titulo = document.querySelector("#tituloModal");

    document.querySelector("#empresa").value = _curso.empresa;
    document.querySelector("#nomeCurso").value = _curso.nome;
    document.querySelector("#descricao").value = _curso.descricao;
    document.querySelector("#qtdAlunos").value = _curso.qtdAlunos;

    btnSalvar.textContent = "Salvar";  
    titulo.textContent = `Editar Curso - ${_curso.nome}`;

    curso = _curso;

    console.log(curso);
}

function Cancelar(){
    var btnSalvar = document.querySelector("#btnSalvar");    
    var titulo = document.querySelector("#tituloModal");

    document.querySelector("#empresa").value = '';
    document.querySelector("#nomeCurso").value = '';
    document.querySelector("#descricao").value = '';
    document.querySelector("#qtdAlunos").value = '';

    aluno = {};

    btnSalvar.textContent = "Cadastrar";
    titulo.textContent = "Cadastrar Curso";

    $('#myModal').modal('hide');
}

function NovoAluno(){
    var btnSalvar = document.querySelector("#btnSalvar");    
    var titulo = document.querySelector("#tituloModal");

    document.querySelector("#empresa").value = '';
    document.querySelector("#nomeCurso").value = '';
    document.querySelector("#descricao").value = '';
    document.querySelector("#qtdAlunos").value = '';

    aluno = {};

    btnSalvar.textContent = "Cadastrar";
    titulo.textContent = "Cadastrar Curso";

    $('#myModal').modal('show');
}
    