using Cinema.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public class SeanceData
    {
        [JsonProperty("content")]
        public List<Seance> Seances { get; set; }

        [JsonProperty("films")]
        public List<Movie> Movies { get; set; }

        [JsonProperty("halls")]
        public List<Hall> Halls { get; set; }

        [JsonProperty("cinemas")]
        public List<Theater> Theaters { get; set; }

    }
}
