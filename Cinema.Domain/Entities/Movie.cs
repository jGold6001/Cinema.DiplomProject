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
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("premiere_ukraine")]
        public string Premiere { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("age_limit")]
        public string AgeLimit { get; set; }
        public Poster Poster { get; set; }
        public Trailer Trailer { get; set; }       
        public List<Person> Persons { get; set; }
        public List<Image> Images { get; set; }

        [JsonProperty("countries")]
        public List<Country> Countries { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        public Movie()
        {
            Persons = new List<Person>();
            Images = new List<Image>();
            Countries = new List<Country>();
            Genres = new List<Genre>();
        }

    }
}
