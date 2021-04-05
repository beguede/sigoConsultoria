using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsultoriasService.Domain.Requests
{
    public interface IRefitNormas
    {
        #region Normas
        /// <summary>
        /// Obter Normas do serviço
        /// </summary>
        /// <returns></returns>
        [Get("/v1/normas")]
        Task<HttpResponseMessage> ObterNormasAsync([Header("Authorization")] string authorization);

        /// <summary>
        /// Obter Norma pelo id
        /// </summary>
        /// <returns></returns>
        [Get("/v1/normas/{id}")]
        Task<HttpResponseMessage> ObterNormaPorIdAsync([Header("Authorization")] string authorization, Guid id);
        #endregion
    }
}
