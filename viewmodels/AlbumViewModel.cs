using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicCatalogue.models;
using MusicCatalogue.models.DTOs;
using MusicCatalogue.models.entites;
using MusicCatalogue.models.interfaces;
using MusicCatalogue.views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MusicCatalogue.viewmodels
{
    public class AlbumViewModel
    {
        private readonly int _publisherID;
        private ObservableCollection<AlbumDTO> _albumDTOs;
        private readonly IServiceProvider _serviceProvider;
        private readonly CatalogueContext _context;
        private readonly IAlbumRepository _albumRepository;
        public ICommand OnDetailsButtonClick { get; }
        public ObservableCollection<AlbumDTO> AlbumDTOs
        {
            get { return _albumDTOs; }
            set
            {
                _albumDTOs = value;
                NotifyPropertyChanged(); 
            }
        }
        private string _property;
        public event PropertyChangedEventHandler PropertyChanged;

        public string property
        {
            get { return _property; }
            set
            {
                if (_property != value)
                {
                    _property = value;
                    NotifyPropertyChanged();
                }
            }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public AlbumViewModel(int publisherID, IServiceProvider serviceProvider)
        {
            _publisherID = publisherID;
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetService<CatalogueContext>();
            AlbumDTOs = new ObservableCollection<AlbumDTO>();
            _albumRepository = _serviceProvider.GetService<IAlbumRepository>();

            OnDetailsButtonClick = new RelayCommand(
                () => ShowDetailView(),
                () => CanShowDetailView());

            InitializeDataGrid();

        }
        private AlbumDTO _selectedAlbum;

        public AlbumDTO SelectedAlbum
        {
            get { return _selectedAlbum; }
            set
            {
                _selectedAlbum = value;
                OnPropertyChanged(nameof(SelectedAlbum));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ShowDetailView()
        {
            var currentView = Application.Current.MainWindow.FindName("albumView") as Window;
            currentView.DataContext = null;

            var detailsView = new DetailsView(SelectedAlbum.Id, _serviceProvider);
            currentView.Hide();
            detailsView.Show();
        }
        private bool CanShowDetailView() => true;

        public void AddAlbum(AlbumDTO album)
        {
            var artistRepository = _serviceProvider.GetService<IArtistRepository>();
            var artistList = album.Artist.Split(',');
            ICollection<Artist> artistsCollection = new Collection<Artist>();

            foreach(var artist in artistList)
            {
                Artist Artist = _context.Artists.FirstOrDefault(p => p.ArtistName == artist);

                if (Artist == null) 
                {
                    Artist = new Artist { ArtistName = artist};
                    artistRepository.Add(Artist);
                }

                artistsCollection.Add(Artist);
            }

            var list = artistRepository.GetAll();
            foreach (var artist in list)
            {
                System.Diagnostics.Debug.WriteLine(artist.ArtistName);
            }

            var addedAlbum = new Album
            {
                Artists = artistsCollection,
                Title = album.Title,
                Year = int.Parse(album.Year),
                Version = album.Version,
                Publisher = _context.Publishers.FirstOrDefault(p => p.PublisherID == _publisherID)
            };

            _albumRepository.Add(addedAlbum);
        }
        public void InitializeDataGrid()
        {
            var albums = _context.Albums
                .Include(a => a.Artists)
                .Where(p => p.Publisher.PublisherID == _publisherID)
                .ToList();

            foreach (var album in albums) 
            {
                var artists = album.Artists.ToList();
                var artistNames = artists.Select(a => a.ArtistName).ToList();
                
                AlbumDTOs.Add(new AlbumDTO
                {
                    Artist = string.Join(",", artistNames),
                    Title = album.Title,
                    Version = album.Version,
                    Year = album.Year.ToString()
                });
            }
        }
    }
}
