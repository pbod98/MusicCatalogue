using MusicCatalogue.models.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogue.models.interfaces
{
    public interface IAlbumRepository
    {
        void Add(Album album);
        void Update(Album album);
        void Remove(Album album);
        Album GetById(int id);
        IEnumerable<Album> GetAll();
    }
}
