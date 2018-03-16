using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.WEB.Controllers;
using Cinema.WEB.Models;
using Cinema.Domain.Services;
using System.Web.Mvc;
using System.Diagnostics;

namespace Cinema.Domain.Tests
{
    [TestClass]
    public class MovieControllerTest
    {
        MovieController controller = new MovieController(new MovieService(), new SeanceService());

        [TestMethod]
        public void GetSeancesByDateTest()
        {
            var times = controller.SeancesByTheaterMovieAndDateTs(8, 47974, "16.03.2018");

            foreach (var item in times)
            {
                Trace.WriteLine($"{item.TimeBegin}  - hall: {item.HallId} - seanseId: {item.SeanceId}");
            }
        }
    }
}
