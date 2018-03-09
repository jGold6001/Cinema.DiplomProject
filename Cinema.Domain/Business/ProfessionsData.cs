using Cinema.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public class ProfessionsData
    {
        [JsonProperty("content")]
        public List<Profession> Professions { get; set; }

    }
}
