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

        //test_entity
        public virtual DbSet<Test> Testes { get; set; }

        //db_entities
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Theater> Theaters { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Poster> Posters { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<Trailer> Trailers { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
      
    }
}
