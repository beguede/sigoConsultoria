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

namespace ConsultoriasService.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/empresas")]
    [ApiController]
    public class EmpresaController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaApplication _empresaApplication;

        public EmpresaController(IMapper mapper, IEmpresaApplication empresaApplication)
        {
            _mapper = mapper;
            _empresaApplication = empresaApplication;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin, Manager, User")]
        [ProducesResponseType(typeof(EmpresaModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {
                var empresa = await _empresaApplication.ObterPorId(id);

                if (empresa.Object == null)
                    return NotFound("Empresa não encontrada");

                return Ok(_mapper.Map<Empresa, EmpresaModel>(empresa.Object));
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "EmpresaController > ObterPorId - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        [ProducesResponseType(typeof(EmpresaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inserir([FromBody] EmpresaModel empresaModel)
        {
            try
            {
                var result = await _empresaApplication.Incluir(empresaModel);

                if (result.Success)
                    return Created($"/empresas/{result.Object.Id}", _mapper.Map<Empresa, EmpresaModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "EmpresaController > Inserir - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Manager")]
        [ProducesResponseType(typeof(EmpresaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar([FromBody] EmpresaModel empresaModel)
        {
            if (empresaModel.Id == null || empresaModel.Id == Guid.Empty)
                return BadRequest("Empresa sem um Id.");

            try
            {
                Empresa empresa = _mapper.Map<Empresa>(empresaModel);
                if (empresa.Invalid)
                    return BadRequest(empresa.Notifications);

                var result = await _empresaApplication.Atualizar(empresaModel);

                if (result.Success)
                    return Ok(_mapper.Map<Empresa, EmpresaModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "EmpresaController > Atualizar - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        [ProducesResponseType(typeof(EmpresaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                await _empresaApplication.Excluir(id);

                return Ok();
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "EmpresaController > Excluir - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager, User")]
        [ProducesResponseType(typeof(IList<EmpresaModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var listaEmpresa = await _empresaApplication.ListarTodos();

                if (listaEmpresa.Object == null)
                    return NotFound("Empresa não encontrada");

                return Ok(_mapper.Map<IEnumerable<Empresa>, IEnumerable<EmpresaModel>>(listaEmpresa.Object));
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "EmpresaController > ListarTodos - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }
    }
}
