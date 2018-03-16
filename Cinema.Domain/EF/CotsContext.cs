using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.EF
{
    public class CotsContext : DbContext
    {
        public CotsContext(string connectionString): base(connectionString)
        {
        }
        
        public virtual DbSet<Theater> Theaters { get; set; }
        public virtual DbSet<MovieDb> Movies { get; set; }  
        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet <TicketModel> TicketModel { get; set; }
        
      
    }
}
