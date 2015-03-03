using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyCinemaddict
{
    public class FilmInfoRepository : LazyCinemaddict.Models.IFilmInfoRepository
    {
        List<FilmInfo> _films;
        ISaver _saver;

        public FilmInfoRepository(ISaver saver)
        {
            _saver = saver;
            _films = saver.Load() ?? new List<FilmInfo>();
        }

        public int GetFilmsCount()
        {
            return _films.Count;
        }

        public void Add(FilmInfo film)
        {
            _films.Add(film);
        }

        public void Save()
        {
            _saver.Save(_films);
        }

        public IEnumerable<FilmInfo> GetAll()
        {
            return _films;
        }

        public IEnumerable<FilmInfo> Get(Func<FilmInfo, bool> filter)
        {
            return _films.Where(filter);
        }

        public FilmInfo GetRandom()
        {
            int rand = new Random().Next(_films.Count);
            return _films[rand];
        }

        public FilmInfo GetCurrent(Guid id)
        {
            return _films.Single(s => s.Id == id);
        }

        public void Remove(FilmInfo film)
        {
            _films.Remove(film);
        }

        public void Remove(Guid id)
        {
            this.Remove(_films.Single(s => s.Id == id));
        }
    }
}
