using PainelDeCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PainelDeCursos.Controllers
{
    public class CursoController : ApiController
    {
        // GET: api/Curso
        public IEnumerable<Curso> Get()
        {
            Curso curso = new Curso();

            return curso.ListarCurso();
        }

        // GET: api/Curso/5
        public Curso Get(int id)
        {
            Curso curso = new Curso();

            return curso.ListarCurso().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/Curso
        public List<Curso> Post(Curso curso)
        {
            Curso _curso = new Curso();

            _curso.Inserir(curso);
                        
            return _curso.ListarCurso();
        }

        // PUT: api/Curso/5
        public Curso Put(int id, [FromBody]Curso curso)
        {
            Curso _curso = new Curso();

            return _curso.Atualizar(id, curso);
        }

        // DELETE: api/Curso/5
        public void Delete(int id)
        {
            Curso _curso = new Curso();

            _curso.Deletar(id);
        }
    }
}
