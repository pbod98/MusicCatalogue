using Microsoft.EntityFrameworkCore;
using MusicCatalogue.models.entites;
using MusicCatalogue.models.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicCatalogue.models.repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private CatalogueContext _context;
        public AlbumRepository(CatalogueContext context)
        {
            _context = context;
        }
        public void Add(Album album)
        {
            _context.Albums.Add(album);
            //_context.Entry(album).Collection(a => a.Artists).Load();
            _context.SaveChanges();
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.Albums.ToList();
        }

        public Album GetById(int id)
        {
            return _context.Albums.Find(id);
        }

        public void Remove(Album album)
        {
            _context.Albums.Remove(album);
            _context.SaveChanges();
        }

        public void Update(Album album)
        {
            throw new NotImplementedException();
        }
    }
}
