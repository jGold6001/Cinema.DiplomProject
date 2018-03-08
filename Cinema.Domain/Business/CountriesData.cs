using Cinema.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public class CountriesData
    {
        [JsonProperty("content")]
        public List<Country> Countries { get; set; }
    }
}
