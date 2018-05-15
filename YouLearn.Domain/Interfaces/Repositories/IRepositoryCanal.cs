using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryCanal
    {
        IEnumerable<Canal> Listar(Guid idUsuario);
        Canal Obter(Guid idCanal);
        Canal Adicionar(Canal canal);
        void Excluir(Canal canal);
    }
}
