using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public class PriceModel
    {
        public int Type { get; set; }
        public decimal Money { get; set; }
        public string Tariff { get; set; }
    }
}