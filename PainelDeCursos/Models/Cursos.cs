using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PainelDeCursos.Models
{
    public class Cursos
    {
        public int id { get; set; }
        public string status { get; set; }
        public string empresa { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public int qtdAlunos { get; set; }

        public List<Cursos> listaCursos()
        {

            Cursos curso1 = new Cursos();
            curso1.id = 1;
            curso1.status = "Ativo";
            curso1.empresa = "Empresa 1";
            curso1.nome = "Curso 1";
            curso1.descricao = "Descrição 1";
            curso1.qtdAlunos = 128;

            Cursos curso2 = new Cursos();
            curso2.id = 2;
            curso2.status = "Ativo";
            curso2.empresa = "Empresa 2";
            curso2.nome = "Curso 2";
            curso2.descricao = "Descrição 2";
            curso2.qtdAlunos = 256;

            List<Cursos> listaCursos = new List<Cursos>();

            listaCursos.Add(curso1);
            listaCursos.Add(curso2);

            return listaCursos;

        }

    }
}