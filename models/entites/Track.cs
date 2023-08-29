using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicCatalogue.models.entites
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        public string Title { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        public Album Album { get; set; }
        public ICollection<Artist> Artists { get; set;}   
    }
}
