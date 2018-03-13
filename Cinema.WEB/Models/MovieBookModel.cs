using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public class MovieBookModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
    }
}