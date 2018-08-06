using System;
using System.Collections.Generic;
using System.Text;

namespace PainelDeCursos.Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        List<TEntity> Listar();
        TEntity Inserir(TEntity tEntity);
        TEntity Atualizar(int id, TEntity tEntity);
        bool Deletar(int Id);
    }
}
