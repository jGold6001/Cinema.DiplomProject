using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public class TheaterModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Site { get; set; }
        
        public string Address { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string PosterBig { get; set; }
    }
}