using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public class SeanceModel
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public List<TimeSeanceModel> Times { get; set; }
        public long MovieId { get; set; }
        public long HallId { get; set; }
        public TheaterModel TheaterModel { get; set; }
    }
}