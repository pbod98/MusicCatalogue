using Dark.Net;
using MusicCatalogue.viewmodels;
using System;
using System.Windows;

namespace MusicCatalogue.views
{
    /// <summary>
    /// Interaction logic for DetailsView.xaml
    /// </summary>
    public partial class DetailsView : Window
    {
        public DetailsView(int albumId, IServiceProvider serviceProvider)
        {
            var viewModel = new DetailsViewModel(albumId, serviceProvider);
            DataContext = viewModel;
            DarkNet.Instance.SetWindowThemeWpf(this, Theme.Auto);
            InitializeComponent();
        }
    }
}
