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

            mapperMovieModelFull = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDb, MovieModelFull>()               
                .ForMember(d => d.Premiere, otp => otp.MapFrom(src => DateTime.ParseExact(src.Premiere, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)))              
                .ForMember(d => d.ImagesUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.Url)))               
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

        [Route("{Id}")]
        public ActionResult MoviePage(long id)
        {
            var movie = movieService.GetOne(id);
            var movieModelFull = mapperMovieModelFull.Map<MovieDb, MovieModelFull>(movie);
            return View(movieModelFull);
        }

        [Route("seances_by_th_m_d/{theaterId:long}/{movieId:long}/{dateStr}")]
        public ActionResult SeancesByTheaterMovieAndDate(long theaterId, long movieId, string dateStr)
        {
            ViewBag.TheaterId = theaterId;
            var date = DateTime.ParseExact(dateStr, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var seanceData = seanceService.GetDataFromAPISeanceByMovieTheaterAndDate(theaterId, movieId, date.ToString("yyyy-MM-dd"));
            var seancesModelForTheater = mapperSeanceModelForTheater.Map<SeanceData, SeancesModelForTheater>(seanceData);
            var seances = seancesModelForTheater.Seances;
            seancesModelForTheater.TimeSeances = GetListSeances(seances);
            
            if (seancesModelForTheater.Seances.Count > 0)
                return PartialView(seancesModelForTheater);
            else
            {              
                ViewBag.TheaterName = (theaterId == 8) ? "Флоренция" : "Boomer";
                return PartialView("WithoutSeances");
            }
                
        }

        [Route("bydate/{dateStr}/{movieId:long}")]
        public ActionResult ByDate(string dateStr, long movieId)
        {
            ViewBag.DateStr = dateStr;
            ViewBag.MovieId = movieId;
            ViewBag.Theaters = new List<int>() { 8, 281 };           
            return PartialView();
        }

        public List<TimeSeanceModel> SeancesByTheaterMovieAndDateTs(long theaterId, long movieId, string dateStr)
        {
            ViewBag.TheaterId = theaterId;
            var date = DateTime.ParseExact(dateStr, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var seanceData = seanceService.GetDataFromAPISeanceByMovieTheaterAndDate(theaterId, movieId, date.ToString("yyyy-MM-dd"));
            var seancesModelForTheater = mapperSeanceModelForTheater.Map<SeanceData, SeancesModelForTheater>(seanceData);

            var seances = seancesModelForTheater.Seances;


            return GetListSeances(seances);
           
        }


        public List<TimeSeanceModel> GetListSeances(List<SeanceModel> seances)
        {
            var timeSeances = new List<TimeSeanceModel>();
            foreach (var seance in seances)
            {
                foreach (var time in seance.Times)
                {
                    time.HallId = seance.HallId;
                    time.SeanceId = seance.Id;
                    timeSeances.Add(time);
                }
            }

            return timeSeances.OrderBy(t => t.TimeBegin).ToList();
        }
    }
}