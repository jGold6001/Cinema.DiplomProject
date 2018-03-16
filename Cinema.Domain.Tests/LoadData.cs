using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain.Services;
using Cinema.Domain.Repositories;
using System.Diagnostics;

namespace Cinema.Domain.Tests
{
    [TestClass]
    public class LoadData
    {
        MovieService movieService = new MovieService();
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsContext");

        [TestMethod]
        public void AddMovies()
        {
            var movies = movieService.GetAllOfCinemasFromApi();
            //movies.Find(m => m.Id == 49415).Actors = null;
            //int i = 0;
            var shrlok = "../Images/slides/banner-1521036365.jpg";
            var vremya = "../Images/slides/banner-1520419017.jpg";
            var lara = "../Images/slides/banner-1521105945.jpg";

            var shrkokM = movies.Find(m=> m.Id == 49108).BannerUrl = shrlok;
            var vremyaM = movies.Find(m => m.Id == 48339).BannerUrl = vremya;
            var laraM = movies.Find(m => m.Id == 47829).BannerUrl= lara;

            foreach (var item in movies)
            {                 
                  movieService.AddOrUpdateMovie(item);
            }

        }

        

        [TestMethod]
        public void RemoveMovies()
        {
            
            foreach (var item in unitOfWork.Movies.GetAll())
            {
                unitOfWork.Movies.Delete(item);
            }

        }


        public void AddMovie()
        {

        }
    }
}
