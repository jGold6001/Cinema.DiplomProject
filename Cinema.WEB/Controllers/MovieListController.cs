using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.WEB.Controllers
{
    public class MovieListController : Controller
    {
        // GET: MovieList
        public ActionResult ListMovies()
        {
            return View();
        }
    }
}