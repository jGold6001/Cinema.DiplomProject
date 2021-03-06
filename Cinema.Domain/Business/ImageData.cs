﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public class ImageData
    {
        [JsonProperty("content")]
        public List<ImageId> Ids { get; set; }
    }

    public class ImageId
    {
        [JsonProperty("id")]
        public long Value { get; set; }
    }
        
}
