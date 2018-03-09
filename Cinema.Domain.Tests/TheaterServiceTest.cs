using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain.Services;
using Cinema.Domain.Repositories;
using Cinema.Domain.Entities;
using System.Diagnostics;

namespace Cinema.Domain.Tests
{
    [TestClass]
    public class TheaterServiceTest
    {
        TheaterService theaterService = new TheaterService();
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsContext");

        [TestMethod]
        public void GetFromAPI_AddOrUpdate_Delete_Theater_Test()
        {
            var theater = theaterService.GetFromAPI(8);
            theater.PosterBig = "https://relax.com.ua/wp-content/media/kiew/2013/02/floren.jpg";
            this.TraceTheater(theater);
            //theaterService.AddOrUpdateTheater(theater);
            theaterService.DeleteTheater(theater.Id);

        }

        public void TraceTheater(Theater theater)
        {
            Trace.WriteLine($"Name: {theater.Name}");
            Trace.WriteLine($"Site: {theater.Site}");
            Trace.WriteLine($"Address: {theater.Address}");
            Trace.WriteLine($"Phone: {theater.Phone}");
            Trace.WriteLine($"Description: {theater.Description}");
            Trace.WriteLine($"Lat: {theater.Latitude}");
            Trace.WriteLine($"Lon: {theater.Longitude}");
            Trace.WriteLine($"Img: {theater.PosterBig}");
        }
    }
}
