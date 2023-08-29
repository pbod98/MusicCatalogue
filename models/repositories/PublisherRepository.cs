using MusicCatalogue.models.entites;
using MusicCatalogue.models.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicCatalogue.models.repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private CatalogueContext _context;

        public PublisherRepository()
        {
        }

        public PublisherRepository(CatalogueContext context)
        {
            _context = context;
        }
        public void Add(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _context.Publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public void Update(Publisher publisher)
        {
            throw new NotImplementedException();
        }
    }
}
