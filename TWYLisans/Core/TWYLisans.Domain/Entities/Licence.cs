using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities.Common;

namespace TWYLisans.Domain.Entities
{
    public class Licence:BaseEntity
    {
        public int productId { get; set; }

        public int customerId { get; set; }

        public DateTime creationDate { get; set; }

        public DateTime endingDate { get; set; }
        [DefaultValue(true)]
        public bool active { get; set; }

        public Guid licencekey { get; set; }

        public virtual Customer customer { get; set; } = null!;

        public virtual Product product { get; set; } = null!;
    }
}
