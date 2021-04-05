using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using ConsultoriasService.Application.Models;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics.CodeAnalysis;

namespace ConsultoriasService.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    public abstract class ApiBaseController : ControllerBase
    {
        protected BadRequestObjectResult BadRequest(IReadOnlyCollection<Notification> notifications)
        {
            return new BadRequestObjectResult(new ErrorModel(notifications));
        }

        protected NotFoundObjectResult NotFound(string message)
        {
            return new NotFoundObjectResult(new ErrorModel(message));
        }

        protected IActionResult Forbidden()
        {
            return StatusCode((int)HttpStatusCode.Forbidden, "Sem permissão de acesso.");
        }

        protected IActionResult NotAcceptable()
        {
            return StatusCode((int)HttpStatusCode.NotAcceptable, "Dados de cadastro inconsistentes.");
        }

        protected IActionResult InternalServerError()
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro interno. Não foi possivel comunicar com o servidor.");
        }
    }
}