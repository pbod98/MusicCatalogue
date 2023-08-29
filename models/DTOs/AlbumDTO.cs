using System.ComponentModel;

namespace MusicCatalogue.models.DTOs
{
    public class AlbumDTO : INotifyPropertyChanged
    {
        private string _artist, _title, _version, _publisher, _year;
        private int _id;

        public AlbumDTO() { }
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }

        public string Artist
        {
            get { return _artist; }
            set
            {
                if (_artist != value)
                {
                    _artist = value;
                    OnPropertyChanged("Artist");
                }
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string Version
        {
            get { return _version; }
            set
            {
                if (_version != value)
                {
                    _version = value;
                    OnPropertyChanged("Version");
                }
            }
        }
        public string Year 
        {
            get { return _year; }
            set
            {
                if (_year != value)
                {
                    _year = value;
                    OnPropertyChanged("Year");
                }
            }
        }
        public string Publisher
        {
            get { return _publisher; }
            set
            {
                if (_publisher != value)
                {    
                    _publisher = value;
                    OnPropertyChanged("Publisher");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
