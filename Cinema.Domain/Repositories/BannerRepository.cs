using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cinema.Domain.Repositories
{
    public class BannerRepository : Repository<Banner>
    {
        public BannerRepository(DbContext context) : base(context)
        {
        }
    }
}
