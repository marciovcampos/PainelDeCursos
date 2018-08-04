using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

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
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaCursos = JsonConvert.DeserializeObject<List<Cursos>>(json);
            
            return listaCursos;

        }

    }
}