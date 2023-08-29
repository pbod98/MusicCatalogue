using Microsoft.EntityFrameworkCore;
using MusicCatalogue.models.entites;

namespace MusicCatalogue.models
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .HasMany(t => t.Tracks)
                .WithOne(a => a.Album);

            modelBuilder.Entity<Publisher>()
                .HasMany(a => a.Albums)
                .WithOne(p => p.Publisher);

            modelBuilder.Entity<Artist>()
                .HasMany(t => t.Tracks)
                .WithMany(a => a.Artists);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Albums)
                .WithMany(a => a.Artists);

            //ptobably not needed
            //modelBuilder.Entity<Album>()
            //    .HasMany(a => a.Artists)
            //    .WithMany(a => a.Albums);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CatalogueDb;TrustServerCertificate=True;Trusted_Connection=SSPI;");
        }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
