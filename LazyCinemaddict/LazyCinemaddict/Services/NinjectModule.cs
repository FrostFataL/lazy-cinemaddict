using LazyCinemaddict.Models;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyCinemaddict.Services
{
    public class MyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            // Связывание выполняется сверху вниз, поэтому располагаем бинды по порядку
            Bind<ISaver>().To<JsonSaver>().WithConstructorArgument("s","Films");
            Bind<IFilmInfoRepository>().To<FilmInfoRepository>();
        }       
    }
}
