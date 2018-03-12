using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain.Services;
using Cinema.Domain.Repositories;
using Cinema.Domain.Entities;
using System.Diagnostics;
using System.Linq;

namespace Cinema.Domain.Tests
{
    [TestClass]
    public class SeanceServiceTest
    {
        SeanceService seanceService = new SeanceService();
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsContext");

        [TestInitialize]
        public void Init()
        {
            
        }

        [TestMethod]
        public void GetAllFromAPISeanceByMovieAndTheater_Test()
        {
            var florence = 8;
            //var redSparrow = 47287;
            var princess = 47974;
            var seances = seanceService.GetAllFromAPISeanceByMovieAndTheater(florence, princess);

            foreach (var item in seances)
            {
                TraceSeance(item);
                Trace.WriteLine("\n********************************************");
            }
        }

        [TestMethod]
        public void GetAllFromAPISeanceByMovieTheaterAndDate_Test()
        {
            var florence = 8;          
            var princess = 47974;
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var seanceData= seanceService.GetDataFromAPISeanceByMovieTheaterAndDate(florence, 47287, date);

            Trace.WriteLine($"----theater: { seanceData.Theaters.FirstOrDefault().Name}");
            foreach (var item in seanceData.Seances)
            {
                TraceSeance(item);
                Trace.WriteLine("\n********************************************");
            }
        }


        private void TraceSeance(Seance seance)
        {
            Trace.WriteLine($"--id: {seance.Id}\n");
            Trace.WriteLine($"--date: {seance.Date}\n");
            Trace.WriteLine($"--times: ");           
            foreach (var item in seance.Times)
            {
                Trace.WriteLine($"{item.TimeBegin.ToShortTimeString()} - prices: {item.Prices} - is 3D: {item.Is3D}");
            }
         
            Trace.WriteLine($"--filmId: {seance.MovieId}\n");
            Trace.WriteLine($"--hallId: { seance.HallId}\n");           
        }
    }
}
