using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace PainelDeCursos.Models
{
    public class Curso
    {
        public int id { get; set; }
        public string status { get; set; }
        public string empresa { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public int qtdAlunos { get; set; }

        public List<Curso> ListarCurso()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaCursos = JsonConvert.DeserializeObject<List<Curso>>(json);
            
            return listaCursos;
        }

        public bool RescreverArquivo(List<Curso> listaCursos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaCursos, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        public Curso Inserir(Curso Curso)
        {
            var listaCursos = this.ListarCurso();

            var maxId = listaCursos.Max(curso => curso.id);
            Curso.id = maxId + 1;
            listaCursos.Add(Curso);

            RescreverArquivo(listaCursos);
            return Curso;
        }


        public Curso Atualizar(int id, Curso Curso)
        {
            var listaCursos = this.ListarCurso();

            var itemIndex = listaCursos.FindIndex(p => p.id == id);

            if (itemIndex >= 0)
            {
                Curso.id = id;
                listaCursos[itemIndex] = Curso;
            }
            else
            {
                return null;
            }

            RescreverArquivo(listaCursos);
            return Curso;
        }

        public bool Deletar(int id)
        {

            var listaCursos = this.ListarCurso();

            var itemIndex = listaCursos.FindIndex(p => p.id == id);

            if (itemIndex >= 0)
            {
                listaCursos.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            RescreverArquivo(listaCursos);
            return true;

        }
        

    }
}