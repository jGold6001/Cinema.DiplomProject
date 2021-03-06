﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain.Services;
using Cinema.Domain.Repositories;
using Cinema.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Cinema.Domain.Tests
{
    [TestClass]
    public class MovieServiceTest
    {
        MovieService movieService = new MovieService();
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsContext");

        //List<Country> countries;
        //List<Genre> genres;
        //List<Profession> professions;

        [TestInitialize]
        public void Init()
        {
            //countries = unitOfWork.Countries.GetAll().ToList();
            //genres = unitOfWork.Genres.GetAll().ToList();
            //professions = unitOfWork.Professions.GetAll().ToList(); 
        }


        [TestMethod]
        public void GetFromAPI_And_Display()
        {
            var movie = movieService.GetFromAPI(47287);
            this.TraceMovie(movie);
        }

        [TestMethod]
        public void GetFomAPI_AddToDB_And_DeleteFromDb_MovieTest()
        {
            var movie = movieService.GetFromAPI(47287);
            movieService.AddOrUpdateMovie(movie);
            movieService.DeleteMovie(47287);
        }


        [TestMethod]
        public void GetFromAPI_ByTheaters()
        {
            //florence
            Trace.WriteLine("--------------------------------Florence-------------------------------------");
            var moviesFl = movieService.GetAllFromAPIByTheater(8);
            foreach (var item in moviesFl)
                Trace.WriteLine($"name: {item.Title} premerie: {item.Premiere}" );

            Trace.WriteLine("\n");

            //boomer
            Trace.WriteLine("----------------------------------Boomer---------------------------------------");
            var moviesBoomer = movieService.GetAllFromAPIByTheater(281);
            foreach (var item in moviesBoomer)
                Trace.WriteLine($"name: {item.Title} premerie: {item.Premiere}");

        }

        [TestMethod]
        public void Add_Countries_Genres_Professions()
        {          
            movieService.GetAllCountriesFromAPIAndAddToDb();
            movieService.GetAllGenresFromAPIAndAddToDb();
            movieService.GetProffesionByIdAndAddToDb();       
        }

        [TestMethod]
        public void GetAllBestFromApi_Test()
        {
            var movies = movieService.GetAllBestFromApi();

            foreach (var item in movies)
            {
                Trace.WriteLine($"{item.Id} - {item.Title} - premerie: {item.Premiere}");
            }

        }

        [TestMethod]
        public void GetAllTodayMoviesFromApi_Test()
        {
            var movies = movieService.GetAllTodayFromApi();

            foreach (var item in movies)
            {
                Trace.WriteLine($"{item.Id} - {item.Title} - Premerie: {item.Premiere}");
            }

            
        }

        [TestMethod]
        public void GetAllMoviesByCinemasFromApi_Test()
        {
            var movies = movieService.GetAllOfCinemasFromApi();

            foreach (var item in movies)
                Trace.WriteLine($"{item.Id} - {item.Title} - IMDB: {item.Rating}");

            //Trace.WriteLine($"last item: {movies.Last().Title}");
            //Trace.WriteLine($"last genre item of last movie: {movies.Last().Genres.Last().Name}");
        }

        [TestMethod]
        public void Delete_Countries_Genres_Professions()
        {
            foreach (var item in unitOfWork.Genres.GetAll())
                unitOfWork.Genres.Delete(item);

            foreach (var item in unitOfWork.Countries.GetAll())
                unitOfWork.Countries.Delete(item);

            foreach (var item in unitOfWork.Professions.GetAll())
                unitOfWork.Professions.Delete(item);

            unitOfWork.Save();
        }

        //public void TraceMovie(Movie movie)
        //{
        //    Trace.WriteLine($"Name: {movie.Title}");
        //    Trace.WriteLine("");
        //    Trace.WriteLine($"premiere: {movie.Premiere}");
        //    Trace.WriteLine("");
        //    Trace.WriteLine($"description: {movie.Description}");
        //    Trace.WriteLine("");
        //    Trace.WriteLine($"year: {movie.Year}");
        //    Trace.WriteLine("");
        //    Trace.WriteLine($"duration: {movie.Duration}");
        //    Trace.WriteLine("");
        //    Trace.WriteLine($"age_limit: {movie.AgeLimit}");

        //    Trace.WriteLine("");
        //    Trace.WriteLine($"posters:");
        //    Trace.WriteLine($"{movie.Poster.Url}");

        //    Trace.WriteLine("");
        //    Trace.WriteLine($"bunnerUrl:");
        //    Trace.Write($"{movie.Poster.Url}");

        //    Trace.WriteLine("");
        //    Trace.WriteLine($"trailer_url: {movie.Trailer.Url}");

        //    //images
        //    Trace.WriteLine($"images: ");
        //    Trace.WriteLine("\n");
        //    foreach (var item in movie.Images)
        //        Trace.WriteLine($"img_{item.Id}: {item.Url}");

        //    //rating
        //    Trace.WriteLine($"rating: {movie.Rating}");

        //    //votes
        //    Trace.WriteLine($"votes: {movie.Votes}");

        //    //directors
        //    Trace.WriteLine("\n");
        //    Trace.WriteLine($"directors: ");
        //    var directors = movie.Persons.FindAll(p => p.ProfessionId == 1);
        //    foreach (var item in directors)
        //        Trace.WriteLine($"{item.FirstName} {item.LastName}");

        //    //actors
        //    Trace.WriteLine("\n");
        //    Trace.WriteLine($"actors: ");
        //    var actors = movie.Persons.FindAll(p => p.ProfessionId == 2);
        //    foreach (var item in actors)
        //        Trace.WriteLine($"{item.FirstName} {item.LastName}");

        //    //countries
        //    Trace.WriteLine("\n");
        //    Trace.WriteLine("countries: ");            
        //    foreach (var item in movie.Countries)
        //        Trace.Write($"{item.Name} | ");

        //    //genres
        //    Trace.WriteLine("\n");
        //    Trace.WriteLine("\n");
        //    Trace.WriteLine("genres: ");
        //    foreach (var item in movie.Genres)
        //        Trace.Write($"{item.Name} | ");


        //}

        public void TraceMovie(Movie movie)
        {
            Trace.WriteLine($"Name: {movie.Title}");
            Trace.WriteLine("");
            Trace.WriteLine($"premiere: {movie.Premiere}");
            Trace.WriteLine("");
            Trace.WriteLine($"description: {movie.Description}");
            Trace.WriteLine("");
            Trace.WriteLine($"year: {movie.Year}");
            Trace.WriteLine("");
            Trace.WriteLine($"duration: {movie.Duration}");
            Trace.WriteLine("");
            Trace.WriteLine($"age_limit: {movie.AgeLimit}");

            Trace.WriteLine("");
            Trace.WriteLine($"posters:");
            Trace.WriteLine($"{movie.PosterUrl}");

            Trace.WriteLine("");
            Trace.WriteLine($"bunnerUrl:");
            Trace.Write($"{movie.PosterUrl}");

            Trace.WriteLine("");
            Trace.WriteLine($"trailer_url: {movie.TrailerUrl}");

            //images
            Trace.WriteLine($"images: ");
            Trace.WriteLine("\n");
            foreach (var item in movie.Images)
                Trace.WriteLine($"img_{item.Id}: {item.Url}");

            //rating
            Trace.WriteLine($"rating: {movie.Rating}");

            //votes
            Trace.WriteLine($"votes: {movie.Votes}");

            //directors
            Trace.WriteLine("\n");
            Trace.WriteLine($"director: {movie.Director}");
            

            //actors
            Trace.WriteLine("\n");
            Trace.WriteLine($"actors: {movie.Actors}");
           

            //countries
            Trace.WriteLine("\n");
            Trace.WriteLine($"countries: {movie.Country}");
          

            //genres
            Trace.WriteLine("\n");
            Trace.WriteLine($"genres: {movie.Genre}");
         


        }

        [TestMethod]
        public void AddBannersToDb()
        {
            //воробей
            var banner_1 = new Banner(47287, "https://s3.amazonaws.com/cinema.tickets.ua/banner/large/banner-1519824616.jpg?1519824624");

            //пантера
            var banner_2 = new Banner(45834, "../Images/slides/banner-1518607607.jpg");

            //ночные игры
            var banner_3 = new Banner(48984, "https://s3.amazonaws.com/cinema.tickets.ua/banner/large/banner-1519203520.jpg?1519203526");

            movieService.AddBannerToDb(banner_1);
            movieService.AddBannerToDb(banner_2);
            movieService.AddBannerToDb(banner_3);
        }

        [TestMethod]
        public void GetFromAPI_isBanner()
        {
            var movies = movieService.GetAllOfCinemasFromApi();
            var null_ = "null";
            foreach (var item in movies)
            {                
                Trace.WriteLine($"{item.Id} - {item.Title} - bunner: {item.BannerUrl ?? null_}");
            }
                
        }

        [TestMethod]
        public void GetAllWithBannersTest()
        {
            var movies = movieService.GetAllWithBanners();
           
            foreach (var item in movies)
                Trace.WriteLine($"{item.Id} - {item.Title} - bunner: {item.BannerUrl}");
        }

        [TestMethod]
        public void ConvertDateFromStringToDateTime_Test()
        {
            DateTime myDate = DateTime.ParseExact("2009-05-08", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);

            Trace.WriteLine(myDate.ToLongDateString());
        }

        
    }
}
