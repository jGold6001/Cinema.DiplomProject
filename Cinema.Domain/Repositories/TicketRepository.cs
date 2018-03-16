using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cinema.Domain.Repositories
{
    public class TicketRepository : Repository<TicketModel>
    {
        public TicketRepository(DbContext context) : base(context)
        {
        }
    }
}
