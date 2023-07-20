using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Customers;
using TWYLisans.Application.ViewModels.Products;

namespace TWYLisans.Application.ViewModels.Licences
{
    public class VM_Create_Licence
    {
        public Guid licencekey { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime endingDate { get; set; }
        public int productId { get; set; }
        public int customerId { get; set; }
    }
}
