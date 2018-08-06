using Newtonsoft.Json;
using PainelDeCursos.Domain.Cursos.Repository;
using PainelDeCursos.Domain.Interfaces;
using PainelDeCursos.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PainelDeCursos.Infra.Data.Repository
{
    public class CursoRepository : ICursoRepository 
    {
        private readonly string FilePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Files/data.json");

        private List<Curso> LerArquivo()
        {
            using (StreamReader r = new StreamReader(FilePath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Curso>>(json);
            }
        }

        public Curso Atualizar(int id, Curso curso)
        {
            var listaCursos = this.Listar();
            var itemIndex = listaCursos.FindIndex(p => p.Id == id);

            if (itemIndex == 0)
                return null;

            curso.Id = id;
            listaCursos[itemIndex] = curso;
            RescreverArquivo(listaCursos);
            return curso;
        }

        public bool Deletar(int id)
        {
            var listaCursos = this.Listar();

            var itemIndex = listaCursos.FindIndex(p => p.Id == id);

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

        public Curso Inserir(Curso curso)
        {
            var listaCursos = this.Listar();

            List<int> ids = new List<int>();            
            foreach (Curso _curso in listaCursos)
            {
                ids.Add(_curso.Id);
            }

            var maxId = ids.Max();
            curso.Id = maxId + 1;

            listaCursos.Add(curso);

            RescreverArquivo(listaCursos);
            return curso;
        }

        public List<Curso> Listar()
        {
            var listaCursos = LerArquivo();
            return listaCursos;
        }

        public bool RescreverArquivo(List<Curso> listaCursos)
        {
            var json = JsonConvert.SerializeObject(listaCursos, Formatting.Indented);
            File.WriteAllText(FilePath, json);
            return true;
        }
    }
}
