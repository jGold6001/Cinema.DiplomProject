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
    public class SeanceService
    {
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsContext");
        string keyAPI = "?apiKey=pol1kh111";
        string host = "http://kino-teatr.ua:8081/services/api";

        public List<Seance> GetAllFromAPISeanceByMovieAndTheater(long theaterId, long movieId)
        {
            var seanceData = JsonFromURL<SeanceData>.ConvertToObject($"{host}/cinema/{theaterId}/film/{movieId}/shows{keyAPI}&size=1000&detalization=FULL");          
            return seanceData.Seances;
        }

        public SeanceData GetDataFromAPISeanceByMovieAndTheater(long theaterId, long movieId)
        {
            return JsonFromURL<SeanceData>.ConvertToObject($"{host}/cinema/{theaterId}/film/{movieId}/shows{keyAPI}&size=1000&detalization=FULL");           
        }

        public SeanceData GetDataFromAPISeanceByMovieTheaterAndDate(long theaterId, long movieId, string date)
        {
             return JsonFromURL<SeanceData>.ConvertToObject($"{host}/cinema/{theaterId}/film/{movieId}/shows{keyAPI}&size=10&date={date}&detalization=FULL");            
        }
    }
}
