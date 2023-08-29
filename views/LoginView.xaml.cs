using Dark.Net;
using MusicCatalogue.models.interfaces;
using MusicCatalogue.viewmodels;
using System;
using System.Windows;

namespace MusicCatalogue.views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView(IServiceProvider serviceProvider)
        {
            var viewModel = new LoginViewModel(serviceProvider);
            DataContext = viewModel;
            DarkNet.Instance.SetWindowThemeWpf(this, Theme.Auto);
            InitializeComponent();
        }
    }
}
