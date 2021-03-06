﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public class MovieModelMainPage
    {     
        public long Id { get; set; }     
        public string Title { get; set; }
        public DateTime Premiere { get; set; }       
        public string Description { get; set; }
        public int? Year { get; set; }       
        public int? Duration { get; set; }    
        public string AgeLimit { get; set; }
        public double? Rating { get; set; }
        public string TrailerUrl { get; set; }
        public long? Votes { get; set; }
        public string PosterURL { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string BannerUrl { get; set; }

    }
}