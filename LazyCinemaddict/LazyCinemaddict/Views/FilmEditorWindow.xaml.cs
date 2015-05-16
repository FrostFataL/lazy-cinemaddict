using LazyCinemaddict.Views;
using Microsoft.Win32;
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
        private string oldImageUrl = "";
        Helper helper;

        public FilmEditorWindow()
        {
            FilmInfo = new FilmInfoViewModel() { WindowTitle = "Добавить фильм" };
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
                WindowTitle = "Редактировать фильм",

                ImageUrl = film.ImageUrl,
                ImagePath = film.ImagePath
            };

            oldImageUrl = FilmInfo.ImageUrl;

            InitializeComponent();
        }

        private void Test_btn_Click(object sender, RoutedEventArgs e)
        {
            //helper = new Helper();
            //helper.Owner = this;
            if( ImageUrltxt.Text != oldImageUrl && ImageUrltxt.Text != "")
                SaveImage(ImageUrltxt.Text);
            //helper.Close();
            DialogResult = true;
            this.Close();
        }

        private void ImageBrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog image = new OpenFileDialog();
            //image.Filter = "";
            //SaveImage();
        }

        private void SaveImage(string url)
        {
            //string image_url = "https://pp.vk.me/c623326/v623326387/2ea6d/1OjQEsho1E0.jpg";
            //string image_url = ImageUrltxt.Text;
            //string path = "Images\\" + Titletxt.Text + ".jpg";
            string path = System.IO.Directory.GetCurrentDirectory() + "\\Images\\" + Titletxt.Text + ".jpg";
            System.Net.WebClient wc = new System.Net.WebClient();
            //wc.DownloadFile(image_url, path);
            wc.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(DownloadProgress);
            wc.DownloadFileAsync(new Uri(url), path);
            FilmInfo.ImagePath = Titletxt.Text + ".jpg";
        }

        private void DownloadProgress(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
                //Helper helper = new Helper();
                //helper.Visibility = System.Windows.Visibility.Visible;
                //helper.Owner = this;
                helper.ProgressBar.Value = e.ProgressPercentage;
                helper.Percent.Text = "" + e.ProgressPercentage + "";
            //helper.Close();
        }

    }
}
