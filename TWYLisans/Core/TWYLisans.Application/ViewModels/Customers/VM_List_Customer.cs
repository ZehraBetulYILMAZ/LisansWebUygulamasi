using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWYLisans.Application.ViewModels.Customers
{
    public class VM_List_Customer
    {
        public int ID { get; set; }
        public DateTime createdDate { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }
        public string town { get; set; }
        public string phoneNumber { get; set; }
        public string ePosta { get; set; }
        public bool gender { get; set; }
       
    }
}
