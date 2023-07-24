using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Application.ViewModels.Products
{
    public class VM_Create_Product
    {
        public string productName { get; set; } 
        public string? productDescription { get; set; }
        public int categoryID { get; set; }
        public List<VM_List_Category> categories { get; set; }=new List<VM_List_Category>();
        public string ?categoryName { get; set; }
     
        public static explicit operator Product (VM_Create_Product model)
        {
            return new Product
            {
                productName = model.productName,
                productDescription = model.productDescription,
                active = true,
                categoryId = model.categoryID,

            };
        }
       

    }
   
    public class VM_List_Category
    {
        public int ID { get; set; }
        public string categoryName { get; set; }
        public static explicit operator VM_List_Category (Category category)
        {
            return new VM_List_Category
            {
                categoryName = category.categoryName,
                ID = category.ID,
            };
        }
    }
}

