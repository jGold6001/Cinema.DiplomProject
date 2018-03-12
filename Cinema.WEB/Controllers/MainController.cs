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
            mapperOnBestMovies = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieModelMainPage>()
                .ForMember(d => d.PosterURL, otp => otp.MapFrom(src => src.Poster.Url))
                .ForMember(d => d.TrailerUrl, opt => opt.MapFrom(s => s.Trailer.Url))
                .ForMember(d => d.Premiere, otp => otp.MapFrom(src => DateTime.ParseExact(src.Premiere, "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)))
                .ForMember(d => d.Genres, otp => otp.MapFrom(src => src.Genres.Select(g => g.Name)))
                .ForMember(d => d.Countries, otp => otp.MapFrom(src => src.Countries.Select(g => g.Name)))           
            ));

            mapperForBanners = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieModelMainPage>()
                .ForMember(d => d.PosterURL, otp => otp.MapFrom(src => src.BannerUrl))
                .ForMember(d => d.Genres, otp => otp.MapFrom(src => src.Genres.Select(g => g.Name)))
                .ForMember(d => d.Premiere, otp => otp.MapFrom(src => DateTime.ParseExact(src.Premiere, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)))
                .ForMember(d => d.Countries, otp => otp.MapFrom(src => src.Countries.Select(g => g.Name)))
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
            var listMoviesModel = mapperForBanners.Map<List<Movie>, List<MovieModelMainPage>>(movies);
            return PartialView(listMoviesModel);
        }

        public ActionResult BestMovies()
        {
            var movies = movieService.GetAllBestFromApi();
            var listMoviesModel = mapperOnBestMovies.Map<List<Movie>, List<MovieModelMainPage>>(movies);
            return PartialView(listMoviesModel);
        }

        public ActionResult TodayMovies()
        {
            var movies = movieService.GetAllTodayFromApi();
            var listMoviesModel = mapperOnBestMovies.Map<List<Movie>, List<MovieModelMainPage>>(movies);
            return PartialView(listMoviesModel);
        }

    }
}