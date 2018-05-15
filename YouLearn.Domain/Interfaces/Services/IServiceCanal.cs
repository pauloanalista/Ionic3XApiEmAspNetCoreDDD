using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceCanal : IServiceBase
    {
        IEnumerable<CanalResponse> Listar(Guid idUsuario);
        CanalResponse AdicionarCanal(AdicionarCanalRequest request, Guid idUsuario);
        Response ExcluirCanal(Guid idCanal);
    }
}
