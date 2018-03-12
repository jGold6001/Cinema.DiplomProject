using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public class SeancesModelForTheater
    {
        public TheaterModel TheaterModel { get; set; }
        public MovieModelMainPage MovieModel { get; set; }
        public List<HallModel> HallModels { get; set; }
        public List<SeanceModel> Seances { get; set; }
     
    }
}