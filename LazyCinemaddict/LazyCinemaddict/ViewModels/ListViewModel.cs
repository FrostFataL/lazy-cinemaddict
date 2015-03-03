using LazyCinemaddict.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyCinemaddict.ViewModels
{
    public class ListViewModel : NotifyBase
    {
        private readonly IFilmInfoRepository filmInfoRepository;

        private IEnumerable<FilmInfo> filteredFilms;
        public IEnumerable<FilmInfo> FilteredFilms {
            get { return filteredFilms; }
            set
            {
                filteredFilms = value;
                OnPropertyChanged();
            }
        }
        public FilmInfo CurrentFilm { get; set; }

        public ListViewModel(IFilmInfoRepository repo)
        {
            filmInfoRepository = repo;
            FilteredFilms = repo.GetAll().OrderBy(s => s.Title);
        }

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
                    FilteredFilms = filmInfoRepository.Get(s => s.Title.ToLower().Contains(_filter.ToLower())).OrderBy(s => s.Title);
                }
                else
                {
                    FilteredFilms = filmInfoRepository.GetAll().OrderBy(s => s.Title);
                }
            }
        }
    }
}
