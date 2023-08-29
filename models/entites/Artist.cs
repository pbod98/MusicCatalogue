using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicCatalogue.models.entites
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public ICollection<Album>? Albums { get; set; }
        public ICollection<Track>? Tracks { get; set; }
    }
}
