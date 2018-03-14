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
    [RoutePrefix("book")]
    public class BookController : Controller
    {
        SeanceService seanceService;
        MovieService movieService;
        TheaterService theaterService;

        IMapper mapperMovieModel, mapperSeanceModel, mapperSeanceDataModel, mapperTheaterModel, mapperTimeSeanceModel, mapperPriceModel;

        public BookController(SeanceService seanceService, MovieService movieService, TheaterService theaterService)
        {
            this.seanceService = seanceService;
            this.movieService = movieService;
            this.theaterService = theaterService;

            mapperMovieModel = new Mapper(new MapperConfiguration(c => c.CreateMap<Movie, MovieBookModel>()
                .ForMember(d => d.PosterUrl, otp => otp.MapFrom(src => src.Poster.Url))
            ));

            mapperTheaterModel = new Mapper(new MapperConfiguration(c => c.CreateMap<Theater, TheaterBookModel>()));

            mapperSeanceModel = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Seance, SeanceModel>()
               .ForMember(d => d.Times, opt => opt.MapFrom(s => s.Times))
           ));

            mapperSeanceDataModel = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SeanceData, SeancesModelForTheater>()
                .ForMember(d => d.MovieModel, opt => opt.MapFrom(src => src.Movies.FirstOrDefault()))
                .ForMember(d => d.HallModels, opt => opt.MapFrom(src => src.Halls))
                .ForMember(d => d.Seances, opt => opt.MapFrom(s => mapperSeanceModel.Map<List<Seance>, List<SeanceModel>>(s.Seances)))
                .ForMember(d => d.TheaterModel, otp => otp.MapFrom(src => src.Theaters.FirstOrDefault()))
            ));

            mapperTimeSeanceModel = new Mapper(new MapperConfiguration(c => c.CreateMap<TimeSeance, TimeSeanceModel>()));
            mapperPriceModel = new Mapper(new MapperConfiguration(c => c.CreateMap<Price, PriceModel>()
                .ForMember(d => d.Tariff, o => o.MapFrom(s => SetTariff(s.Type)))
            ));
        }

        
        // GET: Book
        [Route("cinema/{cinemaId}/hall/{hallId}/seance/{seanceId}/date/{dateSeance}/time/{timeSeanceId}/movie/{movieId}")]
        public ActionResult Hall(long cinemaId, long hallId,long seanceId, string dateSeance,long timeSeanceId, long movieId)
        {
            var seanceData = seanceService.GetDataFromAPISeanceByMovieTheaterAndDate(cinemaId, movieId, dateSeance);
            var movieModel = mapperMovieModel.Map<Movie, MovieBookModel>(movieService.GetFromAPI(movieId));    
            var theaterModel = mapperTheaterModel.Map<Theater, TheaterBookModel>(seanceData.Theaters[0]);            
            var date = DateTime.ParseExact(dateSeance, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            var seanceModel = mapperSeanceModel.Map<Seance, SeanceModel>(seanceData.Seances.Find(s => s.Id == seanceId));
            var timeSeance = seanceModel.Times.Find( t => t.Id == timeSeanceId);

            var hallName = seanceData.Halls.Find(h => h.Id == seanceModel.HallId).Name;
            var technology = (timeSeance.Is3D == true) ? "3D" : "2D";
            var pricesModel = mapperPriceModel.Map<List<Price>, List<PriceModel>>( PriceFormer.Prices(timeSeance.Prices));
            
            var bookData = new BookDataModel(timeSeanceId, hallName, date, movieModel, timeSeance, theaterModel, technology, pricesModel);

            return View(bookData);
        }

        [Route("purchase")]
        public ActionResult Purchase()
        {
            return View();
        }

        [Route("ticket")]
        public ActionResult Ticket()
        {
            return View();
        }

        private string SetTariff(int type)
        {
            switch (type)
            {
                case 1: return "cheap";
                case 2: return "middle";
                case 3: return "expensive";
                case 4: return "vip";
                default: return null;
            }
        }


    }
}