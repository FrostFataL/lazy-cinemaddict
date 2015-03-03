using LazyCinemaddict.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyCinemaddict.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IFilmInfoRepository filmInfoRepository;

        public MainWindowViewModel(IFilmInfoRepository repo)
        {
            filmInfoRepository = repo;
            FilmsCount = filmInfoRepository.GetFilmsCount();
        }

        //public bool HaveCurrentFilm()
        //{
        //    if (FilmTitle != "")
        //        return true;
        //    else
        //        return false;
        //}

        public void GetRandom()
        {
            var filmInfo = filmInfoRepository.GetRandom();
            Id = filmInfo.Id;
            FilmTitle = filmInfo.Title;
            Genre = filmInfo.Genre;
            Duration = filmInfo.Duration;
            Date = filmInfo.Date;
        }

        public FilmInfo GetCurrent()
        {
            return filmInfoRepository.GetCurrent(Id);
        }

        public void Add(FilmInfo film)
        {
            filmInfoRepository.Add(film);
            FilmsCount++;
        }

        public void Update(FilmInfo film)
        {
            FilmTitle = film.Title;
            Genre = film.Genre;
            Duration = film.Duration;
            Date = film.Date;
        }

        public void Save()
        {
            filmInfoRepository.Save();
        }

        public IEnumerable<FilmInfo> GetAll()
        {
            return filmInfoRepository.GetAll();
        }

        public void Remove()
        {
            filmInfoRepository.Remove(Id);
            FilmTitle = null;
            Genre = null;
            Duration = null;
            Date = null;
            FilmsCount--;
        }
    }
}
