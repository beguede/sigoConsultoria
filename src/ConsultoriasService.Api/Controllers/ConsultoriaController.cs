using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsultoriasService.Application.Interfaces;
using ConsultoriasService.Application.Models;
using ConsultoriasService.Domain.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultoriasService.Infrastructure.Requests;

namespace ConsultoriasService.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/consultorias")]
    [ApiController]
    public class ConsultoriaController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IConsultoriaApplication _consultoriaApplication;
        private readonly IRefitNormas _refitNormas;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ConsultoriaController(IMapper mapper, IConsultoriaApplication consultoriaApplication, IRefitNormas refitNormas, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _consultoriaApplication = consultoriaApplication;
            _refitNormas = refitNormas;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin, Manager, User")]
        [ProducesResponseType(typeof(ConsultoriaModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {
                var consultoria = await _consultoriaApplication.ObterPorId(id);

                if (consultoria.Object == null)
                    return NotFound("Consultoria não encontrada");

                return Ok(_mapper.Map<Consultoria, ConsultoriaModel>(consultoria.Object));
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "ConsultoriaController > ObterPorId - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        [ProducesResponseType(typeof(ConsultoriaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inserir([FromBody] ConsultoriaModel consultoriaModel)
        {
            try
            {
                var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                var norma = await _refitNormas.ObterNormaPorIdAsync(accessToken, consultoriaModel.NormaId);

                var result = await _consultoriaApplication.Incluir(consultoriaModel);

                if (result.Success)
                    return Created($"/consultorias/{result.Object.Id}", _mapper.Map<Consultoria, ConsultoriaModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "ConsultoriaController > Inserir - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Manager")]
        [ProducesResponseType(typeof(ConsultoriaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar([FromBody] ConsultoriaModel consultoriaModel)
        {
            if (consultoriaModel.Id == null || consultoriaModel.Id == Guid.Empty)
                return BadRequest("Consultoria sem um Id.");

            try
            {
                Consultoria consultoria = _mapper.Map<Consultoria>(consultoriaModel);
                if (consultoria.Invalid)
                    return BadRequest(consultoria.Notifications);

                var result = await _consultoriaApplication.Atualizar(consultoriaModel);

                if (result.Success)
                    return Ok(_mapper.Map<Consultoria, ConsultoriaModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "ConsultoriaController > Atualizar - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        [ProducesResponseType(typeof(ConsultoriaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                await _consultoriaApplication.Excluir(id);

                return Ok();
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "ConsultoriaController > Excluir - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager, User")]
        [ProducesResponseType(typeof(IList<ConsultoriaModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var listaConsultoria = await _consultoriaApplication.ListarTodos();

                if (listaConsultoria.Object == null)
                    return NotFound("Consultoria não encontrada");

                return Ok(_mapper.Map<IEnumerable<Consultoria>, IEnumerable<ConsultoriaModel>>(listaConsultoria.Object));
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "ConsultoriaController > ListarTodos - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }
    }
}