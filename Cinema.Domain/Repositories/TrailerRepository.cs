using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cinema.Domain.Repositories
{
    public class TrailerRepository : Repository<Trailer>
    {
        public TrailerRepository(DbContext context) : base(context)
        {
        }
    }
}
