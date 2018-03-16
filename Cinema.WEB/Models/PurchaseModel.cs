using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public class PurchaseModel
    {
        public List<TicketModel> Tickets { get; set; }
        public MovieBookModel MovieBookModel { get; set; }
        public string Hall { get; set; }
        public TheaterBookModel TheaterBookModel { get; set; }
        public string Tecnology { get; set; }
        public string seanceDate { get; set; }
        public string SeanceTime { get; set; }

        public PurchaseModel(List<TicketModel> tickets, MovieBookModel movieBookModel, string hall, TheaterBookModel theaterBookModel, string technology, string seanceData, string seanceTime)
        {
            this.Tickets = tickets;
            this.MovieBookModel = movieBookModel;
            this.Hall = hall;
            this.TheaterBookModel = theaterBookModel;
            this.Tecnology = technology;
            this.seanceDate = seanceData;
            this.SeanceTime = seanceTime;
        }
        public PurchaseModel()
        {

        }
    }
}