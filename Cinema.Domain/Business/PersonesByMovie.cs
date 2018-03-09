using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public class PersonesByMovie
    {
        [JsonProperty("content")]
        public List<PersonModel> PersonModels { get; set; }
    }


    public class PersonModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("film_id")]
        public long FilmId { get; set; }

        [JsonProperty("person_id")]
        public long PersonId { get; set; }

        [JsonProperty("profession_id")]
        public long ProfessionId { get; set; }
    }
}
