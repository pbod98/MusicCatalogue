using System.ComponentModel;

namespace MusicCatalogue.models.DTOs
{
    public class TrackDTO
    {
        private string _artist, _title, _duration;
        private int _year;

        public TrackDTO() { }
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
        public int Year
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
        public string Duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    OnPropertyChanged("Duration");
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
