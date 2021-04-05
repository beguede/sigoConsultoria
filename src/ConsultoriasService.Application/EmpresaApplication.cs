using AutoMapper;
using ConsultoriasService.Application.Interfaces;
using ConsultoriasService.Application.Models;
using ConsultoriasService.Domain.Entities;
using ConsultoriasService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultoriasService.Application
{
    public class EmpresaApplication : IEmpresaApplication
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaApplication(IMapper mapper, IEmpresaRepository empresaRepository)
        {
            _mapper = mapper;
            _empresaRepository = empresaRepository;
        }

        public async Task<Result<Empresa>> ObterPorId(Guid id)
        {
            Empresa empresa = await _empresaRepository.ObterPorId(id);
            return Result<Empresa>.Ok(empresa);
        }

        public async Task<Result<Empresa>> Incluir(EmpresaModel empresaModel)
        {
            var empresa = _mapper.Map<EmpresaModel, Empresa>(empresaModel);

            if (empresa.Valid)
            {
                await _empresaRepository.Incluir(empresa);
                return Result<Empresa>.Ok(empresa);
            }

            return Result<Empresa>.Error(empresa.Notifications);
        }

        public async Task<Result<Empresa>> Atualizar(EmpresaModel empresaModel)
        {
            var empresa = _mapper.Map<EmpresaModel, Empresa>(empresaModel);

            if (empresa.Valid)
            {
                await _empresaRepository.Atualizar(empresa);
                return Result<Empresa>.Ok(empresa);
            }

            return Result<Empresa>.Error(empresa.Notifications);
        }

        public async Task Excluir(Guid id)
        {
            await _empresaRepository.Excluir(id);
            return;
        }

        public async Task<Result<IList<Empresa>>> ListarTodos()
        {
            IList<Empresa> listaEmpresa = await _empresaRepository.ListarTodos();
            return Result<IList<Empresa>>.Ok(listaEmpresa);
        }
    }
}
