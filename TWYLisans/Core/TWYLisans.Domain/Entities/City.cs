using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities.Common;

namespace TWYLisans.Domain.Entities
{
    public class City:BaseEntity
    {
        public string cityname { get; set; } = null!;
        public virtual ICollection<Town> towns { get; set; } = new List<Town>();
    }
}
