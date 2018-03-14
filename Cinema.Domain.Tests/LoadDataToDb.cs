using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain.Services;
using Cinema.Domain.Repositories;

namespace Cinema.Domain.Tests
{

    [TestClass]
    public class LoadDataToDb
    {

        MovieService movieService = new MovieService();
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsContext");

        [TestMethod]
        public void LoadMovies()
        {
            var movies = movieService.GetAllOfCinemasFromApi();
        }
    }
}
