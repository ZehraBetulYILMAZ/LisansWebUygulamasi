using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWYLisans.Application.ViewModels.Licences
{
    public class VM_List_Licence
    {
        public int ID { get; set; }
        public DateTime createdDate { get; set; }
        public Guid licenceKey { get; set; }
        public DateTime expiryDate { get; set; }

    }
}
