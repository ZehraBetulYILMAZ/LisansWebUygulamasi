using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Customers;
using TWYLisans.Application.ViewModels.Licences;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Application.ViewModels.Products
{
    public class VM_List_Product
    {
        public int ID { get; set; }
        public string productName { get; set; }
        public string? productDescription { get; set; }
        public string categoryName { get; set; }
        public int categoryId { get; set; }
        public List<VM_List_Category> categories { get; set; } = new List<VM_List_Category>();

        public static explicit operator VM_List_Product (Product product)
        {
            return new VM_List_Product
            {
                ID = product.ID,
                productName = product.productName,
                productDescription = product.productDescription,
                categoryName = product.category.categoryName,
                categoryId=product.categoryId
            };
        }
        public static explicit operator Product(VM_List_Product mProduct)
        {
            return new Product
            {
                ID = mProduct.ID,
                productName = mProduct.productName,
                productDescription = mProduct.productDescription,
                category = new Category
                {
                    ID = mProduct.categoryId,
                    categoryName = mProduct.categoryName
                }
            };
        }

    }
}
