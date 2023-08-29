using Microsoft.Extensions.DependencyInjection;
using MusicCatalogue.models;
using MusicCatalogue.models.DTOs;
using MusicCatalogue.models.interfaces;
using MusicCatalogue.models.repositories;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicCatalogue.viewmodels
{
    public class DetailsViewModel
    {
        private int _albumId;
        private readonly IServiceProvider _serviceProvider;
        private ObservableCollection<AlbumDTO> _trackDTOs;
        private readonly CatalogueContext _context;
        private readonly ITrackRepository _trackRepository;
        private readonly IAlbumRepository _albumRepository;
        public DetailsViewModel(int albumId, IServiceProvider serviceProvider)
        {
            _albumId = albumId;
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetService<CatalogueContext>();
            _albumRepository = _serviceProvider.GetService<AlbumRepository>();

            InitializeDataGrid();
        }
        public ObservableCollection<AlbumDTO> TrackDTOs
        {
            get { return _trackDTOs; }
            set
            {
                _trackDTOs = value;
                NotifyPropertyChanged();
            }
        }
        private string _property;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void AddTrack(TrackDTO track)
        {
            //TODO
        }
        public void InitializeDataGrid()
        {
            //TODO
        }
    }
}
