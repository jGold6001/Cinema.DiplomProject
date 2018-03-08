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
    public class Trailer
    {
        [Key]
        [ForeignKey("Movie")]
        public long Id { get; set; }
        public string Url { get; set; }
  
        public Movie Movie { get; set; }

    }
}