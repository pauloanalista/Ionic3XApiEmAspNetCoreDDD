using System;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario
    {
        Usuario Obter(Guid id);
        Usuario Obter(string email, string senha);
        void Salvar(Usuario usuario);
        bool Existe(string email);
    }
}
