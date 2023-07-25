using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Application.ViewModels.Customers
{
    public class VM_List_Customer
    {
        public int ID { get; set; }
        public string companyName { get; set; }
        public string? ePosta { get; set; }
        public string? phoneNumber { get; set; }
        public string townname { get; set; }
        public string cityname { get; set; }
        public bool active { get; set; }

        public static explicit operator VM_List_Customer (Customer customer)
        {
            return new VM_List_Customer
            {
                cityname = customer.town.city.cityname,
                ePosta = customer.ePosta,
                phoneNumber = customer.phoneNumber,
                townname = customer.town.townname,
                companyName = customer.companyName,
                active = customer.active,
                ID = customer.ID

            };
        }
        public static explicit operator Customer (VM_List_Customer model)
        {
            return new Customer
            {
                ID = model.ID,
                companyName = model.companyName,
                ePosta = model.ePosta,
                phoneNumber = model.phoneNumber,
                active = model.active,
                town = new Town
                {
                    townname = model.townname,
                    city = new City
                    {
                        cityname = model.cityname,
                    }
                },
              
            };
        }

    }
}
