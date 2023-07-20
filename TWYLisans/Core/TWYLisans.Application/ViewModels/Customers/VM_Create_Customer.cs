using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWYLisans.Application.ViewModels.Customers
{
    public class VM_Create_Customer
    {
        public string companyName { get; set; }
        public string? ePosta { get; set; }
        public string? phoneNumber { get; set; }
        public string townname { get; set; }
        public byte[]? mailaddress { get; set; }
        public string cityname { get; set; }
    }
}
