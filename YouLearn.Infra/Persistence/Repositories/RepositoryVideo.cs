using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryVideo : IRepositoryVideo
    {
        private readonly YouLearnContext _context;

        public RepositoryVideo(YouLearnContext context)
        {
            _context = context;
        }

        public void Adicionar(Video video)
        {
            _context.Videos.Add(video);
        }

        public bool ExisteCanalAssociado(Guid idCanal)
        {
            return _context.Videos.Any(x => x.Canal.Id == idCanal);
        }

        public bool ExistePlayListAssociada(Guid idPlayList)
        {
            return _context.Videos.Any(x => x.PlayList.Id==idPlayList);
        }

        public IEnumerable<Video> Listar(string tags)
        {
            var query = _context.Videos.Include(x => x.Canal).Include(x => x.PlayList).AsQueryable();

            tags.Split(' ').ToList().ForEach(tag => {
                query = query.Where(x => x.Tags.Contains(tag) || x.Titulo.Contains(tag) || x.Descricao.Contains(tag));
            });

            return query.ToList();
        }

        public IEnumerable<Video> Listar(Guid idPlayList)
        {
            return _context.Videos.Include(x => x.Canal).Include(x => x.PlayList)
                .Where(x => x.PlayList.Id == idPlayList).ToList();
        }
    }
}
