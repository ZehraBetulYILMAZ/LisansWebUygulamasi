using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Customers;
using TWYLisans.Application.ViewModels.Products;

namespace TWYLisans.Application.ViewModels.Licences
{
    public class VM_ProductsLicence
    {
       public VM_Create_Licence licences { get; set; } = new VM_Create_Licence();
        public List<VM_List_Product> products { get; set; } = new List<VM_List_Product>();
        public List<VM_List_Customer> customers { get; set; } = new List<VM_List_Customer>();
    }
}
