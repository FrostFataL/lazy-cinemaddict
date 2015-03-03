using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LazyCinemaddict
{
    class JsonSaver : ISaver
    {
        string path;

        public JsonSaver(string s)
        {
            path = s;
        }

        public void Save(List<FilmInfo> films)
        {
            StreamWriter sw = new StreamWriter(path);
            var films_json = JsonConvert.SerializeObject(films);
            sw.WriteLine(films_json);
            sw.Close();
        }

        public List<FilmInfo> Load()
        {
            try
            {
                return JsonConvert.DeserializeObject<List<FilmInfo>>(File.ReadAllText(path));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
