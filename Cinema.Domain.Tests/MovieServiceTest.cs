using System;
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
                Trace.WriteLine(item.Title);

            Trace.WriteLine("\n");

            //boomer
            Trace.WriteLine("----------------------------------Boomer---------------------------------------");
            var moviesBoomer = movieService.GetAllFromAPIByTheater(281);
            foreach (var item in moviesBoomer)
                Trace.WriteLine(item.Title);

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
                Trace.WriteLine($"{item.Id} - {item.Title} - IMDB: {item.Rating}");
            }

            Trace.WriteLine($"last item: {movies.Last().Title}");
            Trace.WriteLine($"last genre item of last movie: {movies.Last().Genres.Last().Name}");
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
            Trace.WriteLine($"{movie.Poster.Size380X600}");
            Trace.WriteLine($"{movie.Poster.Size424X424}");
            Trace.WriteLine($"{movie.Poster.Size1920X617}");

            Trace.WriteLine("");
            Trace.WriteLine($"trailer_url: {movie.Trailer.Url}");

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
            Trace.WriteLine($"directors: ");
            var directors = movie.Persons.FindAll(p => p.ProfessionId == 1);
            foreach (var item in directors)
                Trace.WriteLine($"{item.FirstName} {item.LastName}");

            //actors
            Trace.WriteLine("\n");
            Trace.WriteLine($"actors: ");
            var actors = movie.Persons.FindAll(p => p.ProfessionId == 2);
            foreach (var item in actors)
                Trace.WriteLine($"{item.FirstName} {item.LastName}");

            //countries
            Trace.WriteLine("\n");
            Trace.WriteLine("countries: ");            
            foreach (var item in movie.Countries)
                Trace.Write($"{item.Name} | ");

            //genres
            Trace.WriteLine("\n");
            Trace.WriteLine("\n");
            Trace.WriteLine("genres: ");
            foreach (var item in movie.Genres)
                Trace.Write($"{item.Name} | ");


        }

      
    }
}
