using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Customers;

namespace TWYLisans.Application.ViewModels.Products
{
    public class VM_List_Product
    {
        public int ID { get; set; }
        public DateTime createdDate { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public VM_List_Licence licence { get; set; }
        public VM_List_Customer customer { get; set; }
    }
}
