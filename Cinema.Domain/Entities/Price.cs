using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class Price
    {
        public int Type { get; set; }
        public decimal Money { get; set; }

        public Price()
        {

        }

        public Price(int type, decimal money)
        {
            this.Type = type;
            this.Money = money;
        }
    }
}
