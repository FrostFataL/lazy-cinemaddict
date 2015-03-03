using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyCinemaddict
{
    public interface ISaver
    {
        void Save(List<FilmInfo> lst);
        List<FilmInfo> Load();
    }
}
