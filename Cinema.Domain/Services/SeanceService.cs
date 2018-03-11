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

        //public List<>
    }
}
