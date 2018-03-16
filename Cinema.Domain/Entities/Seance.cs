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

        [JsonProperty("film_id")]
        public long MovieId { get; set; }

        public Movie Movie { get; set; }

        [JsonProperty("hall_id")]
        public long HallId { get; set; }

        public long TheaterId { get; set; }

    }

    public class TimeSeance
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("time")]
        public DateTime TimeBegin { get; set; }
        
        [JsonProperty("prices")]
        public string Prices { get; set; }

        [JsonProperty("3d")]
        public bool Is3D { get; set; }

        [JsonProperty("purchase_allowed")]
        public bool PurchaseAllowed { get; set; }
        public long SeanceId { get; set; }
        public long HallId { get; set; }


    }
}
