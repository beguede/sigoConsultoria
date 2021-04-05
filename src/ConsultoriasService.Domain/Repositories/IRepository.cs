using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultoriasService.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Incluir(T obj);

        Task Atualizar(T obj);

        Task Excluir(Guid id);

        Task<T> ObterPorId(Guid id);

        Task<IList<T>> ListarTodos();
    }
}
