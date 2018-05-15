using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{
    public class VideoController : Base.ControllerBase
    {
        private readonly IServiceVideo _serviceVideo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VideoController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unityOfWork, IServiceVideo serviceVideo) : base(unityOfWork)
        {
            _serviceVideo = serviceVideo;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/Video/Listar/{tags}")]
        public async Task<IActionResult> Listar(string tags)
        {
            try
            {
                var response = _serviceVideo.Listar(tags);
                return await ResponseAsync(response, _serviceVideo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/Video/Listar/{idPlayList:Guid}")]
        public async Task<IActionResult> Listar(Guid idPlayList)
        {
            try
            {
                var response = _serviceVideo.Listar(idPlayList);
                return await ResponseAsync(response, _serviceVideo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("api/v1/Video/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarVideoRequest request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _serviceVideo.AdicionarVideo(request, usuarioResponse.Id);

                return await ResponseAsync(response, _serviceVideo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
