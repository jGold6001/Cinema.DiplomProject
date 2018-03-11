using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class Banner
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public string Url { get; set; }

        public Banner()
        {

        }

        public Banner(long id, string url)
        {
            this.Id = id;
            this.Url = url;
        }
    }
}
