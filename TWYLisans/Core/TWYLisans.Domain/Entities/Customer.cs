using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities.Common;

namespace TWYLisans.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string companyName { get; set; }
        public string? ePosta { get; set; }
        public string? phoneNumber { get; set; }
        public int townId { get; set; }
        public byte[] mailaddress { get; set; }

        [DefaultValue(true)]
        public bool active { get; set; }

        public virtual ICollection<Licence> licences { get; set; } = new List<Licence>();

        public virtual Town town { get; set; } = null!;
    }
}
