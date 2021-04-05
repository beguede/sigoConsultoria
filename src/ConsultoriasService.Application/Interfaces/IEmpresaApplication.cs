using ConsultoriasService.Application.Models;
using ConsultoriasService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultoriasService.Application.Interfaces
{
    public interface IEmpresaApplication
    {
        Task<Result<Empresa>> ObterPorId(Guid id);
        Task<Result<Empresa>> Incluir(EmpresaModel normaModel);
        Task<Result<Empresa>> Atualizar(EmpresaModel normaModel);
        Task Excluir(Guid id);
        Task<Result<IList<Empresa>>> ListarTodos();
    }
}
