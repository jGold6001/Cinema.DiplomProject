using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public class TestJsonModels
    {
        [JsonProperty("content")]
        public List<TestJsonModel> Models { get; set; } 

    }

    public class TestJsonModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }

}
