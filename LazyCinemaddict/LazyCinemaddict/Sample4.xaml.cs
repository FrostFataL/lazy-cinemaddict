using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LazyCinemaddict
{
    /// <summary>
    /// Interaction logic for Sample4.xaml
    /// </summary>
    public partial class Sample4 : Window
    {
        public ObservableCollection<Film> Films { get; set; }

        public Film CurrentFilm { get; set; }

        private string _filter;
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                if (!string.IsNullOrEmpty(_filter))
                {
                    listView.ItemsSource = Films.Where(s => s.Name.ToLower().Contains(_filter.ToLower()));
                }
                else
                {
                    listView.ItemsSource = Films;
                }
            }
        }

        public Sample4()
        {
            Films = new ObservableCollection<Film> 
            {
                new Film { Director = "John", Name = "Cow", Time = "1.52", Year = "1959", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "John", Name = "Cow 2", Time = "1.52", Year = "1979", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "Mike", Name = "Friends", Time = "1.20", Year = "2003", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "John", Name = "Cow 2", Time = "1.52", Year = "1979", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "Mike", Name = "Friends", Time = "1.20", Year = "2003", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "John", Name = "Cow 2", Time = "1.52", Year = "1979", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "Mike", Name = "Friends", Time = "1.20", Year = "2003", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "John", Name = "Cow 2", Time = "1.52", Year = "1979", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "Mike", Name = "Friends", Time = "1.20", Year = "2003", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "John", Name = "Cow 2", Time = "1.52", Year = "1979", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "Mike", Name = "Friends", Time = "1.20", Year = "2003", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "John", Name = "Cow 2", Time = "1.52", Year = "1979", ImagePath = new Uri(@"D:\2.jpg")},
                new Film { Director = "Mike", Name = "Friends 2", Time = "1.30", Year = "2015", ImagePath = new Uri(@"D:\2.jpg")}
            };
            InitializeComponent();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(CurrentFilm.Name);
            this.Close();
        }
    }
}
