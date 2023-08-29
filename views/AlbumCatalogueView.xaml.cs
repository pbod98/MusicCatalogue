using Dark.Net;
using MusicCatalogue.models.DTOs;
using MusicCatalogue.viewmodels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MusicCatalogue.views
{
    /// <summary>
    /// Interaction logic for AlbumView.xaml
    /// </summary>
    public partial class AlbumCatalogueView : Window
    {
        private readonly AlbumViewModel _viewModel;
        private bool _isEditingOrAdding;
        public AlbumCatalogueView(int publisherID, IServiceProvider serviceProvider)
        {
            _viewModel = new AlbumViewModel(publisherID, serviceProvider);
            DataContext = _viewModel;
            DarkNet.Instance.SetWindowThemeWpf(this, Theme.Auto);
            InitializeComponent();
        }
        private void AlbumGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var albumData = e.Row.Item as AlbumDTO;

            if (e.EditAction == DataGridEditAction.Commit)
            {
               if(albumData.Artist != null && albumData.Title != null && albumData.Version != null && albumData.Year != null)
                {
                    _viewModel.AddAlbum(albumData);
                }
            }
        }
    }
}
