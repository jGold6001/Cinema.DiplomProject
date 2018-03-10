using Cinema.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public class MoviesByTheater
    {
        [JsonProperty("films")]
        public List<MovieId> Movies { get; set; }
    }

    public class MovieId
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
