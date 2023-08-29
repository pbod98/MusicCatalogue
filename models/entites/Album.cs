using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicCatalogue.models.entites
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public int Year { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<Artist>? Artists { get; set; }
    }
}
