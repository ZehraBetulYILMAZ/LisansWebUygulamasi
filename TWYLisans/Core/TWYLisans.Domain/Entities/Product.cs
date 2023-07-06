using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities.Common;

namespace TWYLisans.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string name { get; set; }
        public string description { get; set; }
        public Category category { get; set; }
        public Customer customer { get; set; }
        public ICollection<Licence> licences { get; set; }
    }
}
