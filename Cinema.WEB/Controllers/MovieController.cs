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
    [RoutePrefix("movie")]
    public class MovieController : Controller
    {
        MovieService movieService;
        IMapper mapperMovieModelFull;

        public MovieController(MovieService movieService)
        {
            this.movieService = movieService;
            mapperMovieModelFull = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieModelFull>()
                .ForMember(d => d.PosterURL, otp => otp.MapFrom(src => src.Poster.Url))
                .ForMember(d => d.TrailerUrl, opt => opt.MapFrom(src => src.Trailer.Url))
                .ForMember(d => d.Genres, otp => otp.MapFrom(src => src.Genres.Select(g => g.Name)))
                .ForMember(d => d.Countries, otp => otp.MapFrom(src => src.Countries.Select(g => g.Name)))
                .ForMember(d => d.ImagesUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.Url)))
                .ForMember(d => d.Director, opt => opt.MapFrom(src => src.Persons.Where(p => p.ProfessionId == 1).Select(p => $"{p.FirstName} {p.LastName}").FirstOrDefault()))
                .ForMember(d => d.Actors, opt => opt.MapFrom(src => src.Persons.Where(p => p.ProfessionId == 2).Select(p => $"{p.FirstName} {p.LastName}")))
            ));
        }

        [Route("test")]
        public ActionResult MoviePage()
        {
            var movie = movieService.GetFromAPI(47287);
            var movieModelFull = mapperMovieModelFull.Map<Movie, MovieModelFull>(movie);
            return View(movieModelFull);
        }

        [Route("{Id}")]
        public ActionResult MoviePage(long id)
        {
            var movie = movieService.GetFromAPI(id);
            var movieModelFull = mapperMovieModelFull.Map<Movie, MovieModelFull>(movie);
            return View(movieModelFull);
        }
    }
}