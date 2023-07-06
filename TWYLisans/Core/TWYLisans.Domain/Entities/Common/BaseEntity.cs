using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWYLisans.Domain.Entities.Common
{
    public class BaseEntity
    {
        public int ID{ get; set; }
        public DateTime createdDate { get; set; }
    }
}
