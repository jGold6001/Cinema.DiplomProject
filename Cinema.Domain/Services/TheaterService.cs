using Cinema.Domain.Business;
using Cinema.Domain.Entities;
using Cinema.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Services
{
    public class TheaterService
    {
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsContext");
        string keyAPI = "?apiKey=pol1kh111";
        string host = "http://kino-teatr.ua:8081/services/api";

        public void AddOrUpdateTheater(Theater theater)
        {
            unitOfWork.Theaters.AddOrUpdate(theater);
            unitOfWork.Save();
        }

        public Theater GetFromAPI(long id)
        {
            var theater = JsonFromURL<Theater>.ConvertToObject($"{host}/cinema/{id}{keyAPI}");
            return theater;
        }

        public void DeleteTheater(long id)
        {
            var theater = unitOfWork.Theaters.Get(id);
            unitOfWork.Theaters.Delete(theater);
            unitOfWork.Save();
        }
    }
}
