using GalaSoft.MvvmLight.Command;
using MusicCatalogue.models.entites;
using MusicCatalogue.models.interfaces;
using System.ComponentModel;
using System.Windows.Input;

namespace MusicCatalogue.viewmodels
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        private Publisher _publisher;
        private IPublisherRepository _publisherRepository;
        public ICommand OnRegisterButtonClick { get; }
        public RegisterViewModel() { }
        public RegisterViewModel(IPublisherRepository repository)
        {
            _publisherRepository = repository;
            _publisher = new Publisher { Login = "", Password = "", PublisherName = "" };

            OnRegisterButtonClick = new RelayCommand(
                () => RegisterPublisher(),
                () => CanRegisterPublisher());

        }
        private void RegisterPublisher()
        {          
            //TODO password ****
            //TODO encryption?

            _publisherRepository.Add(_publisher);

            var list = _publisherRepository.GetAll();

            foreach (Publisher p in list)
            {
                System.Diagnostics.Debug.WriteLine("publisher:");
                System.Diagnostics.Debug.WriteLine(p.PublisherID);
                System.Diagnostics.Debug.WriteLine(p.Login);
                System.Diagnostics.Debug.WriteLine(p.Password);
                System.Diagnostics.Debug.WriteLine(p.PublisherName);
            }
        }

        private bool CanRegisterPublisher()
        {
            //TODO check whether user with specific login exists

            if (_publisher.PublisherName != "" && _publisher.Login != "" && _publisher.Password != "")
            {
                return true;
            }
            else
            {
                return false;
            }
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
                }
            }
        }
        public string PublisherName
        {
            get { return _publisher.PublisherName; }
            set
            {
                if (_publisher.PublisherName != value)
                {
                    _publisher.PublisherName = value;
                    RaisePropertyChanged("PublisherName");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            //PropertyChangedEventHandler handler = PropertyChanged;
        
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
