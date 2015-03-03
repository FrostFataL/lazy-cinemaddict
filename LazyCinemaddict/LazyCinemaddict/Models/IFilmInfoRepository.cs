using System;
namespace LazyCinemaddict.Models
{
    public interface IFilmInfoRepository
    {
        void Add(global::LazyCinemaddict.FilmInfo film);
        global::System.Collections.Generic.IEnumerable<global::LazyCinemaddict.FilmInfo> Get(Func<global::LazyCinemaddict.FilmInfo, bool> filter);
        global::System.Collections.Generic.IEnumerable<global::LazyCinemaddict.FilmInfo> GetAll();
        global::LazyCinemaddict.FilmInfo GetCurrent(Guid id);
        global::LazyCinemaddict.FilmInfo GetRandom();
        void Remove(global::LazyCinemaddict.FilmInfo film);
        void Remove(Guid id);
        void Save();
        int GetFilmsCount();
    }
}
