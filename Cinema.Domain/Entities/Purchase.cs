using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class Purchase
    {
        public long Id { get; set; }
        public List<TicketModel> Tickets { get; set; }
        public long MovieId { get; set; }
        public MovieDb movieDb { get; set; }
        public string Hall { get; set; }
        public long TheaterId { get; set; }
        public Theater Theater { get; set; }
        public string Tecnology { get; set; }
        public string SeanceDate { get; set; }
        public string SeanceTime { get; set; }
    }

    public class TicketModel
    {    
        public long Id { get; set; }
        public string Place { get; set; }
        public decimal Price { get; set; }
        public long PurchaseId { get; set;}
        public Purchase Purchase { get; set; }
        public long TimeSeanceId { get; set; }
    }

}
