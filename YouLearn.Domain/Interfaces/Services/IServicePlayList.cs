using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServicePlayList : IServiceBase
    {
        IEnumerable<PlayListResponse> Listar(Guid idUsuario);
        PlayListResponse AdicionarPlayList(AdicionarPlayListRequest request, Guid idUsuario);
        Response ExcluirPlayList(Guid idPlayList);
    }
}
