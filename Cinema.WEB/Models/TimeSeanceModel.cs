using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public  class TimeSeanceModel
    {
        public long Id { get; set; }
        public DateTime TimeBegin { get; set; }  
        public string Prices { get; set; }  
        public bool Is3D { get; set; }
        public bool PurchaseAllowed { get; set; }
      
    }
}