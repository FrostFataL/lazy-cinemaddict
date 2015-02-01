using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyCinemaddict
{
    public class FilmInfoRepository
    {
        List<FilmInfo> _films;
        ISaver _saver;
        public ISaver Saver 
        {
            get 
            {
                if (_saver == null)
                    _saver = new DefaultSaver();
                return _saver;
            }

            set
            {
                _saver = value;
                _films = _saver.Load() ?? new List<FilmInfo>();
            }
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
            int rand = new Random().Next(_films.Count - 1);
            return _films[rand];
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
