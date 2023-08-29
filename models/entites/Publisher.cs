using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicCatalogue.models.entites
{
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }
        public string PublisherName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Album>? Albums { get; set; }
    }
}
