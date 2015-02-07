using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace LazyCinemaddict
{
    /// <summary>
    /// Interaction logic for NewFilm.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FilmInfoRepository repo;

        public MainWindow()
        {
            InitializeComponent();
            repo = new FilmInfoRepository();
            repo.Saver = new JsonSaver("Films");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            repo.Save();
            this.Close();
        }

        private void UpdateFilm_Click(object sender, RoutedEventArgs e)
        {
            var q = repo.GetAll().FirstOrDefault();
            FilmEditorWindow film = new FilmEditorWindow(q);
            film.Owner = this;
            if (film.ShowDialog() == true)
            {
                q.Title = film.FilmInfo.FilmTitle;
                q.Date = film.FilmInfo.Date;
                q.Genre = film.FilmInfo.Genre;
                q.Duration = film.FilmInfo.Duration;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FilmEditorWindow film = new FilmEditorWindow();
            film.Owner = this;
            if (film.ShowDialog() == true)
            {
                repo.Add(new FilmInfo()
                {
                    Genre = film.FilmInfo.Genre,
                    Date = film.FilmInfo.Date,
                    Duration = film.FilmInfo.Duration,
                    Title = film.FilmInfo.FilmTitle
                });
            }
        }
    }
}
