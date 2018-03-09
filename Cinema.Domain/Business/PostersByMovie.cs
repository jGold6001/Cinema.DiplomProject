using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public class PostersByMovie
    {
        [JsonProperty("content")]
        public List<PosterId> Ids { get; set; }
    }

    public class PosterId
    {
        [JsonProperty("id")]
        public long Value { get; set; }
    }
}
