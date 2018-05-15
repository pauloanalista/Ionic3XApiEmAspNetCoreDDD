using System;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Arguments.Video
{
    public class VideoResponse
    {
        public string NomeCanal { get; set; }
        public Guid? IdPlayList { get; set; }
        public string NomePlayList { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Thumbnail { get; set; }
        public string IdVideoYoutube { get; set; }
        public int OrdemNaPlayList { get; set; }
        public string Url { get; set; }

        public static explicit operator VideoResponse(Entities.Video entidade)
        {
            return new VideoResponse()
            {
                Descricao = entidade.Descricao,
                Url = string.Concat("https://www.youtube.com/embed/", entidade.IdVideoYoutube),
                NomeCanal = entidade.Canal.Nome,
                IdVideoYoutube = entidade.IdVideoYoutube,
                Thumbnail = string.Concat("https://img.youtube.com/vi/", entidade.IdVideoYoutube, "/mqdefault.jpg"),
                Titulo = entidade.Titulo,
                IdPlayList = entidade.PlayList?.Id,
                NomePlayList = entidade.PlayList?.Nome,
                OrdemNaPlayList = entidade.OrdemNaPlayList
            };
        }
    }
}
