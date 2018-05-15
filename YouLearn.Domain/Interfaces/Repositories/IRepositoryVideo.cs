using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryVideo
    {
        void Adicionar(Video video);
        IEnumerable<Video> Listar(string tags);
        IEnumerable<Video> Listar(Guid idPlayList);
        bool ExisteCanalAssociado(Guid idCanal);
        bool ExistePlayListAssociada(Guid idPlayList);
    }
}
