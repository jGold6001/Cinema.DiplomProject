using Cinema.Domain.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<MovieService>().To<MovieService>();
            Bind<TheaterService>().To<TheaterService>();
        }
    }
}