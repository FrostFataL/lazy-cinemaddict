using LazyCinemaddict.Models;
using LazyCinemaddict.Services;
using LazyCinemaddict.ViewModels;
using Ninject;
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
        private MainWindowViewModel viewModel;
        private readonly IFilmInfoRepository filmInfoRepository;

        public MainWindow()
        {
            InitializeComponent();
            var kernel = new StandardKernel(new MyNinjectModule());
            filmInfoRepository = kernel.Get<IFilmInfoRepository>();
            this.viewModel = new MainWindowViewModel(filmInfoRepository);
            DataContext = viewModel;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            viewModel.Save();
            this.Close();
        }

        private void UpdateFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentFilm = viewModel.GetCurrent();
                FilmEditorWindow film = new FilmEditorWindow(currentFilm);
                film.Owner = this;
                if (film.ShowDialog() == true)
                {
                    currentFilm.Title = film.FilmInfo.FilmTitle;
                    currentFilm.Date = film.FilmInfo.Date;
                    currentFilm.Genre = film.FilmInfo.Genre;
                    currentFilm.Duration = film.FilmInfo.Duration;
                }
                viewModel.Update(currentFilm);
            }
            catch(Exception)
            {
                MessageBox.Show("Фильм не выбран!");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FilmEditorWindow film = new FilmEditorWindow();
            film.Owner = this;
            if (film.ShowDialog() == true)
            {
                viewModel.Add(new FilmInfo()
                {
                    Genre = film.FilmInfo.Genre,
                    Date = film.FilmInfo.Date,
                    Duration = film.FilmInfo.Duration,
                    Title = film.FilmInfo.FilmTitle
                });
            }
        }

        private void RandomFilmBtn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.GetRandom();
        }

        private void RemoveFilmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.Remove();
            }
            catch (Exception)
            {
                MessageBox.Show("Фильм не выбран!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListViewModel lstModel = new ListViewModel(filmInfoRepository);
            AllFilmsList filmsList = new AllFilmsList(lstModel);
            filmsList.Owner = this;
            if (filmsList.ShowDialog() == true)
            {
                viewModel.FilmTitle = lstModel.CurrentFilm.Title;
                viewModel.Date = lstModel.CurrentFilm.Date;
                viewModel.Id = lstModel.CurrentFilm.Id;
                viewModel.Genre = lstModel.CurrentFilm.Genre;
                viewModel.Duration = lstModel.CurrentFilm.Duration;
            }
        }
    }
}
