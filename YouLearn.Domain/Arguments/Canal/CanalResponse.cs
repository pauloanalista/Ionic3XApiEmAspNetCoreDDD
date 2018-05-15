using System;

namespace YouLearn.Domain.Arguments.Canal
{
    public class CanalResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UrlLogo { get; set; }

        public static explicit operator CanalResponse(Entities.Canal entidade)
        {
            return new CanalResponse() {
                Id = entidade.Id,
                Nome = entidade.Nome,
                UrlLogo = entidade.UrlLogo
            };
        }
    }
}
