using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class Image
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public long MovieId { get; set; }
        public MovieDb Movie { get; set;}

        public Image()
        {

        }

        public Image(string url, long movieId)
        {
            this.Url = url;
            this.MovieId = movieId;
        }
    }
}