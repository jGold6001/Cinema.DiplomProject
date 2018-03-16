using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.WEB.Models
{
    public class TicketModel
    {
        public string Place { get; set; }
        public decimal Price { get; set; }
        public long TimeSeanceId { get; set; }
    }
}