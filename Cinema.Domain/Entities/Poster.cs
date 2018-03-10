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

        public string Size380X600 { get; set; }
        public string Size424X424 { get; set; }
        public string Size1920X617 { get; set; }

        public Movie Movie { get; set; }

        public Poster(long id, string size_1, string size_2, string size_3)
        {
            this.Id = id;
            this.Size380X600 = size_1;
            this.Size424X424 = size_2;
            this.Size1920X617 = size_3;
        }

        public Poster()
        {

        }
    }
}