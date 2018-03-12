using AutoMapper;
using Cinema.Domain.Business;
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
    [RoutePrefix("movie")]
    public class MovieController : Controller
    {
        MovieService movieService;
        SeanceService seanceService;
        IMapper mapperMovieModelFull, mapperSeanceModelForTheater, mapperSeanceModel;

        public MovieController(MovieService movieService, SeanceService seanceService)
        {
            this.movieService = movieService;
            this.seanceService = seanceService;

            mapperMovieModelFull = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieModelFull>()
                .ForMember(d => d.PosterURL, otp => otp.MapFrom(src => src.Poster.Url))
                .ForMember(d => d.Premiere, otp => otp.MapFrom(src => DateTime.ParseExact(src.Premiere, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)))
                .ForMember(d => d.TrailerUrl, opt => opt.MapFrom(src => src.Trailer.Url))
                .ForMember(d => d.Genres, otp => otp.MapFrom(src => src.Genres.Select(g => g.Name)))
                .ForMember(d => d.Countries, otp => otp.MapFrom(src => src.Countries.Select(g => g.Name)))
                .ForMember(d => d.ImagesUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.Url)))
                .ForMember(d => d.Director, opt => opt.MapFrom(src => src.Persons.Where(p => p.ProfessionId == 1).Select(p => $"{p.FirstName} {p.LastName}").FirstOrDefault()))
                .ForMember(d => d.Actors, opt => opt.MapFrom(src => src.Persons.Where(p => p.ProfessionId == 2).Select(p => $"{p.FirstName} {p.LastName}")))
            ));
            

            mapperSeanceModel = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Seance, SeanceModel>()
                .ForMember(d => d.Times, opt => opt.MapFrom(s => s.Times))
            ));

            mapperSeanceModelForTheater = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SeanceData, SeancesModelForTheater>()
                .ForMember(d => d.MovieModel, opt => opt.MapFrom(src => src.Movies.FirstOrDefault()))
                .ForMember(d => d.HallModels, opt => opt.MapFrom(src => src.Halls))
                .ForMember(d => d.Seances, opt => opt.MapFrom(s => mapperSeanceModel.Map<List<Seance>, List<SeanceModel>>(s.Seances)))
                .ForMember(d => d.TheaterModel, otp => otp.MapFrom(src => src.Theaters.FirstOrDefault()))
            ));
        }

        //[Route("test")]
        //public ActionResult MoviePage()
        //{
        //    ViewBag.BaseUrl = Request.Url.Authority;
        //    var movie = movieService.GetFromAPI(47974);
        //    var movieModelFull = mapperMovieModelFull.Map<Movie, MovieModelFull>(movie);
        //    return View(movieModelFull);
        //}

        [Route("{Id}")]
        public ActionResult MoviePage(long id)
        {
            var movie = movieService.GetFromAPI(id);
            var movieModelFull = mapperMovieModelFull.Map<Movie, MovieModelFull>(movie);
            return View(movieModelFull);
        }

        [Route("seances_by_th_m_d/{theaterId:long}/{movieId:long}/{dateStr}")]
        public ActionResult SeancesByTheaterMovieAndDate(long theaterId, long movieId, string dateStr)
        {
            var date = DateTime.ParseExact(dateStr, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var seanceData = seanceService.GetDataFromAPISeanceByMovieTheaterAndDate(theaterId, movieId, date.ToString("yyyy-MM-dd"));
            var seancesModelForTheater = mapperSeanceModelForTheater.Map<SeanceData, SeancesModelForTheater>(seanceData);
            return PartialView(seancesModelForTheater);
        }

        [Route("bydate/{dateStr}/{movieId:long}")]
        public ActionResult ByDate(string dateStr, long movieId)
        {
            ViewBag.DateStr = dateStr;
            ViewBag.MovieId = movieId;
            ViewBag.Theaters = new List<int>() { 8, 281 };           
            return PartialView();
        }

        [Route("bydate/test")]
        public ActionResult ByDateTest()
        {          
            return PartialView();
        }
    }
}