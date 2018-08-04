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
        public IEnumerable<Cursos> Get()
        {
            Cursos curso = new Cursos();

            return curso.listaCursos();
        }

        // GET: api/Curso/5
        public Cursos Get(int id)
        {
            Cursos curso = new Cursos();

            return curso.listaCursos().Where(x => x.id == id).FirstOrDefault();

        }

        // POST: api/Curso
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Curso/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Curso/5
        public void Delete(int id)
        {
        }
    }
}
