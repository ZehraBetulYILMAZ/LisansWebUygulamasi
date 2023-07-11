using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities.Common;

namespace TWYLisans.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }
        public string town{ get; set; }
        public string phoneNumber { get; set; }
        public string ePosta { get; set; }
        public bool gender { get; set; }
        public ICollection<Product> ?products { get; set; }
    }
}
