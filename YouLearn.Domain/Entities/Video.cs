using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Entities
{
    public class Video : EntityBase
    {
        protected Video()
        {

        }
        public Video(Canal canal, PlayList playList, string titulo, string descricao, string tags, int? ordemNaPlayList, string idVideoYoutube, Usuario usuarioSugeriu)
        {
            Canal = canal;
            PlayList = playList;
            Titulo = titulo;
            Descricao = descricao;
            Tags = tags;
            OrdemNaPlayList = ordemNaPlayList.HasValue? ordemNaPlayList.Value : 0;
            IdVideoYoutube = idVideoYoutube;
            UsuarioSugeriu = usuarioSugeriu;
            Status = EnumStatus.EmAnalise;

            new AddNotifications<Video>(this)
                .IfNullOrInvalidLength(x => x.Titulo, 1, 200, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Titulo", "1", "200"))
                .IfNullOrInvalidLength(x => x.Descricao, 1, 255, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descrição", "1", "255"))
                .IfNullOrInvalidLength(x => x.Tags, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Tag", "1", "100"))
                .IfNullOrInvalidLength(x => x.IdVideoYoutube, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Id do Youtube", "1", "50"))
            ;

            AddNotifications(canal);

            if (playList != null)
            {
                AddNotifications(playList);
            }
        }

        public Canal Canal { get; private set; }
        public PlayList PlayList { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Tags { get; private set; }
        public int OrdemNaPlayList { get; private set; }
        public string IdVideoYoutube { get; private set; }
        public Usuario UsuarioSugeriu { get; private set; }
        public EnumStatus Status { get; private set; }

    }
}
