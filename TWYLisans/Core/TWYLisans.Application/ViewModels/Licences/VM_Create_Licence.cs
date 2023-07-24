using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Customers;
using TWYLisans.Application.ViewModels.Products;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Application.ViewModels.Licences
{
    public class VM_Create_Licence
    {
        public Guid licencekey { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime endingDate { get; set; }
        public int productId { get; set; }
        public int customerId { get; set; }
        public string companyName { get; set; }

        //public static explicit operator VM_Create_Licence(Licence licence)
        //{
        //    return new VM_Create_Licence
        //    {
        //        creationDate = licence.creationDate,
        //        endingDate = licence.endingDate,
        //        productId = licence.productId,
        //        customerId = licence.customerId,
        //        licencekey = licence.licencekey
        //    };
        //}
        public static explicit operator Licence(VM_Create_Licence model)
        {
            return new Licence
            {
                creationDate = model.creationDate,
                endingDate = model.endingDate,
                productId = model.productId,
                licencekey = model.licencekey,
                customerId = model.customerId,
            };
        }
    }
}
