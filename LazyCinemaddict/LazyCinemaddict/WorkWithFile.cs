using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;
using System.IO;

namespace LazyCinemaddict
{
    /// <summary>
    /// Работа с данными
    /// </summary>
    public class WorkWithFile
    {
        List<FilmInfo> film_lst = new List<FilmInfo>();

        /// <summary>
        /// Считывание файла
        /// </summary>
        public WorkWithFile()
        {
            try
            {
                StreamReader sr = new StreamReader("Films");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var res = JsonConvert.DeserializeObject<FilmInfo>(line);
                    film_lst.Add(res);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Запись данных в файл
        /// </summary>
        public void WriteToFile()
        {
            StreamWriter sw = new StreamWriter("Films");
            var jsonFilms = JsonConvert.SerializeObject(film_lst);
            sw.WriteLine(jsonFilms);
            sw.Close();
        }

        /// <summary>
        /// Добавление нового фильма
        /// </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        /// <param name="genre"></param>
        /// <param name="duration"></param>
        public void AddNewFilm(FilmInfo film)
        {
            film_lst.Add(film);
        }
    }
}
