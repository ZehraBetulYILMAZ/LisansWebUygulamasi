using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Products;

namespace TWYLisans.Application.ViewModels.Customers
{
    public class VM_Details_Customer
    {
        public VM_List_Customer customer{ get; set;}
        public List<VM_List_Product> products { get; set;}
        
    }
}
