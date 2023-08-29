using Microsoft.EntityFrameworkCore;
using MusicCatalogue.models.entites;
using MusicCatalogue.models.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogue.models.repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private CatalogueContext _context;
        public ArtistRepository(CatalogueContext context)
        {
            _context = context;
        }
        public void Add(Artist artist)
        {
            _context.Artists.Add(artist);
            _context.SaveChanges();
        }

        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists.ToList();
        }

        public Artist GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void Update(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}
