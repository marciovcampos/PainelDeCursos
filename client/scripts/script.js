var tbody = document.querySelector('table tbody');
var curso = {};

carregaCursos();

function Cadastrar(){
            
    curso.Company = document.querySelector("#empresa").value;
    curso.Name = document.querySelector("#nomeCurso").value;
    curso.Description = document.querySelector("#descricao").value;
    curso.Quantity = document.querySelector("#qtdAlunos").value;
    
    if (curso.Id === undefined || curso.Id === 0){
        salvarCursos('POST', 0, curso); 
    }else{
        salvarCursos('PUT', curso.Id, curso); 
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

function excluir(curso){    
    bootbox.confirm({
        message: `Tem certeza que deseja excluir o curso ${curso.Name}?`,
        buttons: {
            confirm: {
                label: 'SIM',
                className: 'btn-success'
            },
            cancel: {
                label: 'NÃO',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if(result){
                excluirCurso(curso.Id);
                carregaCursos();
            }
        }
    });
}

function adicionaLinha(curso){
    
    var trow = `<tr>
                <td>${curso.Company}</td>
                <td>${curso.Name}</td>
                <td>${curso.Description}</td>
                <td>${curso.Quantity}</td> 
                <td>
                    <button class="btn btn-info" data-toggle="modal" data-target="#myModal" onclick='editarCurso(${JSON.stringify(curso)})'>Editar</button>             
                    <button class="btn btn-danger" onclick='excluir(${JSON.stringify(curso)})'>Excluir</button>
                </td>              
            </tr>`;

    tbody.innerHTML += trow;

}

function editarCurso(_curso){
    var btnSalvar = document.querySelector("#btnSalvar");    
    var titulo = document.querySelector("#tituloModal");

    document.querySelector("#empresa").value = _curso.Company;
    document.querySelector("#nomeCurso").value = _curso.Name;
    document.querySelector("#descricao").value = _curso.Description;
    document.querySelector("#qtdAlunos").value = _curso.Quantity;

    btnSalvar.textContent = "Salvar";  
    titulo.textContent = `Editar Curso - ${_curso.Name}`;

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
    