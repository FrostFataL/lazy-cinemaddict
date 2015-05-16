using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyCinemaddict.ViewModels
{
    public class ViewModelBase : NotifyBase
    {
        Guid id;
        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        string windowTitle;
        public string WindowTitle
        {
            get
            {
                return windowTitle;
            }
            set
            {
                windowTitle = value;
                OnPropertyChanged();
            }
        }

        string filmTitle;
        public string FilmTitle
        {
            get
            {
                return filmTitle;
            }
            set
            {
                filmTitle = value;
                OnPropertyChanged();
            }
        }

        DateTime? date;
        public DateTime? Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }

        string genre;
        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
                OnPropertyChanged();
            }
        }

        int? duration;
        public int? Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
                OnPropertyChanged();
            }
        }

        string imageUrl;
        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }
            set
            {
                imageUrl = value;
                OnPropertyChanged();
            }
        }

        string imagePath;
        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                OnPropertyChanged();
            }
        }

        int filmsCount;
        public int FilmsCount
        {
            get
            {
                return filmsCount;
            }
            set
            {
                filmsCount = value;
                OnPropertyChanged();
            }
        }
    }
}
