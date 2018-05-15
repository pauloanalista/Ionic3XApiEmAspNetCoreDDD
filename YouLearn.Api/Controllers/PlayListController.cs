using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{
    public class PlayListController : Base.ControllerBase
    {

        private readonly IServicePlayList _servicePlayList;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlayListController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unityOfWork, IServicePlayList servicePlayList) : base(unityOfWork)
        {
            _servicePlayList = servicePlayList;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("api/v1/PlayList/Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _servicePlayList.Listar(usuarioResponse.Id);
                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("api/v1/PlayList/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarPlayListRequest request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _servicePlayList.AdicionarPlayList(request, usuarioResponse.Id);

                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/PlayList/Excluir/{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                var response = _servicePlayList.ExcluirPlayList(id);

                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
