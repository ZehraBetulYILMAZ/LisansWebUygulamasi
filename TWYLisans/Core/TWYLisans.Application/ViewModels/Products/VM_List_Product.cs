using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Customers;
using TWYLisans.Application.ViewModels.Licences;

namespace TWYLisans.Application.ViewModels.Products
{
    public class VM_List_Product
    {
        public int ID { get; set; }
        public string productName { get; set; }
        public string? productDescription { get; set; }
        public string categoryName { get; set; }

    }
}
