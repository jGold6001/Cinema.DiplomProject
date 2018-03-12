using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public class HallModel
    {
        public long Id { get; set; }
        public string Name { get; set; }       
        public long TheaterId { get; set; }       
        public bool Is3D { get; set; }
    }
}