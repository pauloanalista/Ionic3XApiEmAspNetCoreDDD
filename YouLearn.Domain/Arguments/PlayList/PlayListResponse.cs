using System;

namespace YouLearn.Domain.Arguments.PlayList
{
    public class PlayListResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator PlayListResponse(Entities.PlayList entidade)
        {
            return new PlayListResponse() {
                Id = entidade.Id ,
                Nome = entidade.Nome
            };
        }
    }
}
