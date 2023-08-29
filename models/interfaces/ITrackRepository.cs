using MusicCatalogue.models.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogue.models.interfaces
{
    public interface ITrackRepository
    {
        void Add(Track track);
        void Update(Track track);
        void Remove(Track track);
        Track GetById(int id);
        IEnumerable<Track> GetAll();
    }
}
