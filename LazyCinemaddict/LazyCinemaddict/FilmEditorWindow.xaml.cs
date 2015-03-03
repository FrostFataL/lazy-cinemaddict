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
    public partial class FilmEditorWindow : Window
    {
        public FilmInfoViewModel FilmInfo { get; set; }

        public FilmEditorWindow()
        {
            FilmInfo = new FilmInfoViewModel() { WindowTitle = "Add new film" };
            InitializeComponent();
        }

        public FilmEditorWindow(FilmInfo film)
        {
            FilmInfo = new FilmInfoViewModel
            {
                Id = film.Id,
                FilmTitle = film.Title,
                Date = film.Date,
                Genre = film.Genre,
                Duration = film.Duration,
                WindowTitle = "Update film"
            };

            InitializeComponent();
        }

        private void Test_btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
