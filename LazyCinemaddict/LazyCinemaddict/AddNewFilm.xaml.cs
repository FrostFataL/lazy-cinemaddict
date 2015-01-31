using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LazyCinemaddict
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddNewFilm : Window, INotifyPropertyChanged
    {
        WorkWithFile wwf;

        string title;
        public string FilmTitle
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("FilmTitle");
            }
        }

        DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
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
                OnPropertyChanged("Genre");
            }
        }

        int duration;
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
                OnPropertyChanged("Duration");
            }
        }

        public AddNewFilm(WorkWithFile file)
        {
            InitializeComponent();
            wwf = file;
        }

        private void Test_btn_Click(object sender, RoutedEventArgs e)
        {
            FilmInfo info = new FilmInfo { Title = this.FilmTitle, Date = this.Date, Genre = this.Genre, Duration = this.Duration };
            wwf.AddNewFilm(info);
            this.Close();
        }

        private void WriteFile(object sender, EventArgs e)
        {
            wwf.WriteToFile();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
