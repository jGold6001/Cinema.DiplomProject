using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class Poster
    {
        [Key]
        [ForeignKey("Movie")]
        public long Id { get; set; }

        public string Url { get; set; }
        public Movie Movie { get; set; }

        public Poster(long id, string url)
        {
            this.Id = id;
            this.Url = url;
        }
    }
}