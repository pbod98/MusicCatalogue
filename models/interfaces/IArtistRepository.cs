using MusicCatalogue.models.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogue.models.interfaces
{
    public interface IArtistRepository
    {
        void Add(Artist artist);
        void Update(Artist artist);
        void Remove(Artist artist);
        Artist GetById(int id);
        IEnumerable<Artist> GetAll();
    }
}
