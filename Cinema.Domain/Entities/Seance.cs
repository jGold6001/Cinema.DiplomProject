using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class Seance
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("begin")]
        public string Date { get; set; }

        [JsonProperty("times")]
        public List<TimeSeance> Times { get; set; }
    }

    public class TimeSeance
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        //[JsonProperty("time")]
        //public DateTime
    }
}
