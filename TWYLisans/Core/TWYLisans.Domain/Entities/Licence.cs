using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities.Common;

namespace TWYLisans.Domain.Entities
{
    public class Licence:BaseEntity
    {
        public Guid licenceKey { get; set; }
        public DateTime expiryDate { get; set; }
        public int productID { get; set; }
        public Product ?product { get; set; }
    }
}
