using Dark.Net;
using Microsoft.Extensions.DependencyInjection;
using MusicCatalogue.models.interfaces;
using MusicCatalogue.viewmodels;
using System.Windows;

namespace MusicCatalogue.views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView(IPublisherRepository repository)
        {
            var viewModel = new RegisterViewModel(repository);
            DataContext = viewModel;
            DarkNet.Instance.SetWindowThemeWpf(this, Theme.Auto);
            InitializeComponent();
        }
    }
}
