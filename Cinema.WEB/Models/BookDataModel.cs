using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public class BookDataModel
    {
        public long Id { get; set; }
        public string HallName { get; set; }
        public string Technology { get; set; }
        public DateTime DateSeance { get; set; }
        public MovieBookModel MovieBookModel { get; set; }
        public TimeSeanceModel TimeSeanceModel { get; set; }
        public TheaterBookModel TheaterBookModel { get; set; }

        public BookDataModel()
        {

        }

        public BookDataModel(long id, string hallName, DateTime dateSeance, MovieBookModel movieBookModel, TimeSeanceModel timeSeanceModel, TheaterBookModel theaterBookModel, string technology)
        {
            this.Id = id;
            this.HallName = hallName;
            this.DateSeance = dateSeance;
            this.MovieBookModel = movieBookModel;
            this.TimeSeanceModel = timeSeanceModel;
            this.TheaterBookModel = theaterBookModel;
            this.Technology = technology;
        }
    }
}