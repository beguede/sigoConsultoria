using ConsultoriasService.Application.Models;
using ConsultoriasService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultoriasService.Application.Interfaces
{
    public interface IConsultoriaApplication
    {
        Task<Result<Consultoria>> ObterPorId(Guid id);
        Task<Result<Consultoria>> Incluir(ConsultoriaModel normaModel);
        Task<Result<Consultoria>> Atualizar(ConsultoriaModel normaModel);
        Task Excluir(Guid id);
        Task<Result<IList<Consultoria>>> ListarTodos();
    }
}
