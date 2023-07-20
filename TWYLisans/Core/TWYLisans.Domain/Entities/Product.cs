using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities.Common;

namespace TWYLisans.Domain.Entities
{
    public class Product:BaseEntity
    {

        public string productName { get; set; } = null!;

        public string? productDescription { get; set; }

        public int categoryId { get; set; }
        [DefaultValue(true)]
        public bool active { get; set; }

        public virtual Category category { get; set; } = null!;

        public virtual ICollection<Licence> licences { get; set; } = new List<Licence>();
    }
}
