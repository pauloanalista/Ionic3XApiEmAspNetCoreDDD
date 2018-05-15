using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Services
{
    public class ServiceVideo : Notifiable, IServiceVideo
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryCanal _repositoryCanal;
        private readonly IRepositoryPlayList _repositoryPlayList;
        private readonly IRepositoryVideo _repositoryVideo;

        public ServiceVideo(IRepositoryUsuario repositoryUsuario, IRepositoryCanal repositoryCanal, IRepositoryPlayList repositoryPlayList, IRepositoryVideo repositoryVideo)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryCanal = repositoryCanal;
            _repositoryPlayList = repositoryPlayList;
            _repositoryVideo = repositoryVideo;
        }

        public AdicionarVideoResponse AdicionarVideo(AdicionarVideoRequest request, Guid idUsuario)
        {
            if (request == null)
            {
                AddNotification("AdicionarVideoRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarVideoRequest"));
                return null;
            }

            Usuario usuario = _repositoryUsuario.Obter(idUsuario);
            if (usuario == null)
            {
                AddNotification("Usuario", MSG.X0_NAO_INFORMADO.ToFormat("Usuário"));
                return null;
            }

            Canal canal = _repositoryCanal.Obter(request.IdCanal);
            if (canal == null)
            {
                AddNotification("Canal", MSG.X0_NAO_INFORMADO.ToFormat("Canal"));
                return null;
            }

            PlayList playList = null;
            if (request.IdPlayList != Guid.Empty)
            {
                playList = _repositoryPlayList.Obter(request.IdPlayList);
                if (playList == null)
                {
                    AddNotification("PlayList", MSG.X0_NAO_INFORMADA.ToFormat("playList"));
                    return null;
                }
            }

            var video = new Video(canal, playList, request.Titulo, request.Descricao, request.Tags, request.OrdemNaPlayList, request.IdVideoYoutube, usuario);

            AddNotifications(video);

            if (this.IsInvalid()) return null;

            _repositoryVideo.Adicionar(video);

            return new AdicionarVideoResponse(video.Id);
        }

        public IEnumerable<VideoResponse> Listar(string tags)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.Listar(tags);

            var response = videoCollection.ToList().Select(entidade => (VideoResponse)entidade);

            return response;
        }

        public IEnumerable<VideoResponse> Listar(Guid idPlayList)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.Listar(idPlayList);

            var response = videoCollection.OrderBy(x=>x.OrdemNaPlayList).ToList().Select(entidade => (VideoResponse)entidade);

            return response;
        }
    }
}
