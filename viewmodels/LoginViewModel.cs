using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.DependencyInjection;
using MusicCatalogue.models;
using MusicCatalogue.models.entites;
using MusicCatalogue.models.interfaces;
using MusicCatalogue.views;
using Prism.Commands;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MusicCatalogue.viewmodels
{
    public class LoginViewModel
    {
        public ICommand RegisterCommand { get; }
        public DelegateCommand SignInCommand { get; set; }
        private readonly IPublisherRepository _publisherRepository;
        private Publisher _publisher;
        private readonly IServiceProvider _serviceProvider;
        private bool _canSignIn;

        public LoginViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _publisherRepository = _serviceProvider.GetService<IPublisherRepository>();
            _publisher = new Publisher { Login = "", Password = "", PublisherName = "" };

                RegisterCommand = new RelayCommand(
                () => ShowRegisterView(),
                () => CanShowRegisterView());

            SignInCommand = new DelegateCommand(SignIn, () => CanSignIn);
        }
        public string Login
        {
            get { return _publisher.Login; }
            set
            {
                if (_publisher.Login != value)
                {
                    _publisher.Login = value;
                    RaisePropertyChanged("Login");
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string Password
        {
            get { return _publisher.Password; }
            set
            {
                if (_publisher.Password != value)
                {
                    _publisher.Password = value;
                    RaisePropertyChanged("Password");
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private bool UserExists()
        {
            var context = _serviceProvider.GetService<CatalogueContext>();
            var user = context.Publishers.FirstOrDefault(p => p.Login == _publisher.Login && p.Password == _publisher.Password);

            if (user != null)
            {
                _publisher = user;
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("User does not exist.");
                return false;
            }
        }
        private bool UpdateCanSignIn()
        {
            if(string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                System.Diagnostics.Debug.WriteLine("fill every textbox");
            }

            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password) && UserExists();
        }
        public bool CanSignIn
        {
            get 
            {
                _canSignIn = UpdateCanSignIn();
                return _canSignIn; 
            }
            set
            {
                _canSignIn = value;
                RaisePropertyChanged("CanSignIn");
            }
        }

        private void SignIn()
        {
            System.Diagnostics.Debug.WriteLine("User {0} signed in", _publisher.PublisherName);

            var currentView = Application.Current.MainWindow.FindName("loginView") as Window;

            var list = _publisher.Albums;

            if(list != null)
            {
                foreach (var item in list)
                {
                    System.Diagnostics.Debug.WriteLine(item.Title);
                }
            }


            currentView.DataContext = null;

            var albumView = new AlbumCatalogueView(_publisher.PublisherID, _serviceProvider);
            System.Diagnostics.Debug.WriteLine(_publisher.PublisherID);
            currentView.Hide();
            albumView.Show();

        }
        private void ShowRegisterView()
        {
            var currentView = Application.Current.MainWindow.FindName("loginView") as Window;
            currentView.DataContext = null;

            var registerView = new RegisterView(_publisherRepository);
            currentView.Hide();
            registerView.Show();
        }
        private bool CanShowRegisterView() => true;
    }
}
