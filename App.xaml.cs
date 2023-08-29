using System;
using System.Windows;
using Dark.Net;
using Microsoft.Extensions.DependencyInjection;
using MusicCatalogue.models;
using MusicCatalogue.models.interfaces;
using MusicCatalogue.models.repositories;
using MusicCatalogue.views;

namespace MusicCatalogue
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private CatalogueContext _context;
        public IServiceProvider IServiceProvider { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DarkNet.Instance.SetCurrentProcessTheme(Theme.Auto);

            _context = new CatalogueContext();

            var services = new ServiceCollection();
            services.AddSingleton(_context);
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            IServiceProvider = services.BuildServiceProvider();

            var StartupView = new LoginView(IServiceProvider);
            StartupView.Show();

        }  
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _context.Dispose();
        }
    }

}
