using AutoMapper;
using ConsultoriasService.Application.Interfaces;
using ConsultoriasService.Application.Models;
using ConsultoriasService.Domain.Entities;
using ConsultoriasService.Domain.Models;
using ConsultoriasService.Domain.Repositories;
using ConsultoriasService.Domain.Requests;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ConsultoriasService.Application
{
    public class ConsultoriaApplication : IConsultoriaApplication
    {
        private readonly IMapper _mapper;
        private readonly IConsultoriaRepository _consultoriaRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IRefitNormas _refitNormas;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ConsultoriaApplication(IMapper mapper, IConsultoriaRepository consultoriaRepository, IEmpresaRepository empresaRepository, IRefitNormas refitNormas, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _consultoriaRepository = consultoriaRepository;
            _empresaRepository = empresaRepository;
            _refitNormas = refitNormas;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<Consultoria>> ObterPorId(Guid id)
        {
            Consultoria consultoria = await _consultoriaRepository.ObterPorId(id);
            return Result<Consultoria>.Ok(consultoria);
        }

        public async Task<Result<Consultoria>> Incluir(ConsultoriaModel consultoriaModel)
        {
            var consultoria = _mapper.Map<ConsultoriaModel, Consultoria>(consultoriaModel);

            var validaNorma = await ValidaNorma(consultoriaModel.NormaId);
            consultoria.AddNotifications(validaNorma);

            var validaEmpresa = await ValidaEmpresa(consultoriaModel.EmpresaId);
            consultoria.AddNotifications(validaEmpresa);

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

            var validaNorma = await ValidaNorma(consultoriaModel.NormaId);
            consultoria.AddNotifications(validaNorma);

            var validaEmpresa = await ValidaEmpresa(consultoriaModel.EmpresaId);
            consultoria.AddNotifications(validaEmpresa);

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

        private async Task<IList<Notification>> ValidaNorma(Guid normaId)
        {
            var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            var normaResult = await _refitNormas.ObterNormaPorIdAsync(accessToken, normaId);
            if (normaResult.IsSuccessStatusCode)
            {
                var response = await normaResult.Content.ReadAsStringAsync();
                var normalModel = JsonConvert.DeserializeObject<NormaModel>(response);

                if (normalModel is null)
                {
                    return new List<Notification> { new Notification("NormaId", "Id da norma inexistente.") };
                }
            }
            else if (normaResult.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<Notification> { new Notification("NormaId", "Id da norma inexistente.") };
            }
            else
            {
                return new List<Notification> { new Notification("NormaId", "Validar id da norma.") };
            }
            return null;
        }

        private async Task<IList<Notification>> ValidaEmpresa(Guid empresaId)
        {
            var empresa = await _empresaRepository.ObterPorId(empresaId);
            if (empresa is null)
                return new List<Notification> { new Notification("EmpresaId", "Id da empresa inexistente.") };
            return null;
        }
    }
}
