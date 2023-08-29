using System.Collections.Generic;
using MusicCatalogue.models.entites;

namespace MusicCatalogue.models.interfaces
{
    public interface IPublisherRepository
    {
        void Add(Publisher publisher);
        void Update(Publisher publisher);
        void Remove(Publisher publisher);
        Publisher GetById(int id);
        IEnumerable<Publisher> GetAll();
    }
}
