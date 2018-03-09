using Cinema.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public class TrailersData
    {
        [JsonProperty("content")]
        public List<Trailer> trailers { get; set; }
    }
}
