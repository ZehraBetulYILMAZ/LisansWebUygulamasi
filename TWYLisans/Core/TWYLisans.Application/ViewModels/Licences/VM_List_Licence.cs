using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Application.ViewModels.Licences
{
    public class VM_List_Licence
    {
        public int ID { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime endingDate { get; set; }
        public int productId { get; set; }
        public int customerId { get; set; }
        public Guid licenceKey { get; set; }
        public string companyName { get; set; }
        public string productName { get; set; }

        public static explicit operator VM_List_Licence(Licence licence)
        {
            return new VM_List_Licence
            {
                creationDate = licence.creationDate,
                endingDate = licence.endingDate,
                licenceKey = licence.licencekey,
                ID = licence.ID,
                customerId = licence.customerId,
                companyName=licence.customer.companyName,
                productId=licence.productId,
                productName=licence.product.productName
                
            };
        }
        public static explicit operator Licence (VM_List_Licence model)
        {
            return new Licence
            {
                ID = model.ID,
                creationDate = model.creationDate,
                endingDate = model.endingDate,
                licencekey = model.licenceKey
            };
        }
    }
}
