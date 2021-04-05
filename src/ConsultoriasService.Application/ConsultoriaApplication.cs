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
    public class ConsultoriaApplication : IConsultoriaApplication
    {
        private readonly IMapper _mapper;
        private readonly IConsultoriaRepository _consultoriaRepository;

        public ConsultoriaApplication(IMapper mapper, IConsultoriaRepository consultoriaRepository)
        {
            _mapper = mapper;
            _consultoriaRepository = consultoriaRepository;
        }

        public async Task<Result<Consultoria>> ObterPorId(Guid id)
        {
            Consultoria consultoria = await _consultoriaRepository.ObterPorId(id);
            return Result<Consultoria>.Ok(consultoria);
        }

        public async Task<Result<Consultoria>> Incluir(ConsultoriaModel consultoriaModel)
        {
            var consultoria = _mapper.Map<ConsultoriaModel, Consultoria>(consultoriaModel);

            if (consultoria.Valid)
            {
                await _consultoriaRepository.Incluir(consultoria);
                return Result<Consultoria>.Ok(consultoria);
            }

            return Result<Consultoria>.Error(consultoria.Notifications);
        }

        public async Task<Result<Consultoria>> Atualizar(ConsultoriaModel consultoriaModel)
        {
            var consultoria = _mapper.Map<ConsultoriaModel, Consultoria>(consultoriaModel);

            if (consultoria.Valid)
            {
                await _consultoriaRepository.Atualizar(consultoria);
                return Result<Consultoria>.Ok(consultoria);
            }

            return Result<Consultoria>.Error(consultoria.Notifications);
        }

        public async Task Excluir(Guid id)
        {
            await _consultoriaRepository.Excluir(id);
            return;
        }

        public async Task<Result<IList<Consultoria>>> ListarTodos()
        {
            IList<Consultoria> listaConsultoria = await _consultoriaRepository.ListarTodos();
            return Result<IList<Consultoria>>.Ok(listaConsultoria);
        }
    }
}
