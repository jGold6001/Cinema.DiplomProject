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
        IMapper mapperOnMovieModelMainPage;

        public MainController(MovieService movieService)
        {
            this.movieService = movieService;
            mapperOnMovieModelMainPage = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieModelMainPage>()
                .ForMember(d => d.PosterURL, otp => otp.MapFrom(src => src.Poster.Size380X600))
                .ForMember(d => d.Genres, otp => otp.MapFrom(src => src.Genres.Select(g => g.Name)))
                .ForMember(d => d.Countries, otp => otp.MapFrom(src => src.Countries.Select(g => g.Name)))
            //.ForMember(d => d.DateIssue, opt => opt.MapFrom(src => src.DateIssue.ToShortDateString()))
            ));
        }
        
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Banner()
        {
            return PartialView();
        }

        public ActionResult BestMovies()
        {
            var movies = movieService.GetAllBestFromApi();
            var listMoviesModel = mapperOnMovieModelMainPage.Map<List<Movie>, List<MovieModelMainPage>>(movies);
            return PartialView(listMoviesModel);
        }

        public ActionResult ListMovies()
        {
            return View();
        }
    }
}