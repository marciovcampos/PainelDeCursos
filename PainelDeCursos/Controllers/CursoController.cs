using PainelDeCursos.Domain.Cursos.Repository;
using PainelDeCursos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PainelDeCursos.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CursoController : ApiController
    {
        public ICursoRepository CursoRepository { get; }

        public CursoController(ICursoRepository cursoRepository)
        {
            CursoRepository = cursoRepository;
        }

        // GET: api/Curso
        public IEnumerable<Curso> Get()
        {
            return CursoRepository.Listar().Where(x => x.Status.Equals("Active")).OrderBy(x => x.Company).ToList();
        }

        // GET: api/Curso/5
        public Curso Get(int id)
        {
            return CursoRepository.Listar().Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Curso
        public List<Curso> Post(Curso curso)
        {
            CursoRepository.Inserir(curso);                        
            return CursoRepository.Listar();
        }

        // PUT: api/Curso/5
        public Curso Put(int id, [FromBody]Curso curso)
        {
            return CursoRepository.Atualizar(id, curso);
        }

        // DELETE: api/Curso/5
        public void Delete(int id)
        {
            CursoRepository.Deletar(id);
        }
    }
}
