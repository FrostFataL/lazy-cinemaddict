using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LazyCinemaddict
{
    [JsonObject]
    public class FilmInfo
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }

        public FilmInfo()
        {
            Id = Guid.NewGuid();
        }
    }
}
