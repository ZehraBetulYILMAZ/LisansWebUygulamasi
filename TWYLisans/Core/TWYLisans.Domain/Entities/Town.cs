using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities.Common;

namespace TWYLisans.Domain.Entities
{
    public class Town:BaseEntity
    {
        public int cityId { get; set; }

        public string townname { get; set; }

        public virtual City city { get; set; } = null!;

        public virtual ICollection<Customer> customers { get; set; } = new List<Customer>();
    }
}
