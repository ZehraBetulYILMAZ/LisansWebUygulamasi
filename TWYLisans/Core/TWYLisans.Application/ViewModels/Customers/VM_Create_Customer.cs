using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Application.ViewModels.Customers
{
    public class VM_Create_Customer
    {
        public string companyName { get; set; }
        public string? ePosta { get; set; }
        public string? phoneNumber { get; set; }
        public string townname { get; set; }
        public string mailaddress { get; set; }
        public string cityname { get; set; }

        public static explicit operator VM_Create_Customer(Customer customer)
        {
            return new VM_Create_Customer
            {
                cityname = customer.town.city.cityname,
                ePosta = customer.ePosta,
                phoneNumber = customer.phoneNumber,
                townname = customer.town.townname,
                companyName = customer.companyName,
            };
        }
        public static explicit operator Customer (VM_Create_Customer model)
        {
            return new Customer
            {
                companyName = model.companyName,
                ePosta = model.ePosta,
                town = new Town
                {
                    townname = model.townname,
                    city = new City
                    {
                        cityname = model.cityname,
                    }
                },
                phoneNumber = model.phoneNumber,
                active = true
            };
        }


    }
}
