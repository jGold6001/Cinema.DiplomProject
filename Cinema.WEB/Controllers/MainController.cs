using AutoMapper;
using Cinema.Domain.Entities;
using Cinema.Domain.Services;
using Cinema.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.WEB.Controllers
{
    public class MainController : Controller
    {
        MovieService movieService;
        IMapper mapperOnBestMovies, mapperForBanners;

        public MainController(MovieService movieService)
        {
            this.movieService = movieService;
            mapperOnBestMovies = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDb, MovieModelMainPage>()               
                .ForMember(d => d.Premiere, otp => otp.MapFrom(src => DateTime.ParseExact(src.Premiere, "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)))                  
            ));

            mapperForBanners = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDb, MovieModelMainPage>()
                .ForMember(d => d.Premiere, otp => otp.MapFrom(src => DateTime.ParseExact(src.Premiere, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)))
            ));


        }
        
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Banners()
        {
            var movies = movieService.GetAllWithBanners();
            var listMoviesModel = mapperForBanners.Map<List<MovieDb>, List<MovieModelMainPage>>(movies);
            return PartialView(listMoviesModel);
        }

        public ActionResult BestMovies()
        {
            var movies = movieService.GetAllBestFromApi();
            var listMoviesModel = mapperOnBestMovies.Map<List<MovieDb>, List<MovieModelMainPage>>(movies);
            return PartialView(listMoviesModel);
        }

        public ActionResult TodayMovies()
        {
            var movies = movieService.GetAllTodayFromApi();
            var listMoviesModel = mapperOnBestMovies.Map<List<MovieDb>, List<MovieModelMainPage>>(movies);
            return PartialView(listMoviesModel);
        }

    }
}