using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Products;

namespace TWYLisans.Application.ViewModels.Licences
{
    public class VM_ProductsLicence
    {
        public int customerId { get; set; }
        public VM_Create_Licence licences { get; set; }
        public VM_Create_Product products { get; set; }
    }
}
