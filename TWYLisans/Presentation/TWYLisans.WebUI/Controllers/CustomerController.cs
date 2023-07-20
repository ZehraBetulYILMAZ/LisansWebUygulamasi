using Microsoft.AspNetCore.Mvc;
using TWYLisans.Application.Repositories;
using TWYLisans.Application.ViewModels.Customers;
using TWYLisans.Application.ViewModels.Products;
using TWYLisans.Domain.Entities;
using TWYLisans.Infrastructure;

namespace TWYLisans.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IReadCustomerRepository _readCustomerRepository;
        private readonly IWriteCustomerRepository _writeCustomerRepository;
        private readonly IProductReadRepository _readProductRepository;
        bool isOk = false;
        public CustomerController(IReadCustomerRepository readCustomerRepository, IWriteCustomerRepository writeCustomerRepository , IProductReadRepository productReadRepository)
        {

            _readCustomerRepository = readCustomerRepository;
            _writeCustomerRepository = writeCustomerRepository;
            _readProductRepository = productReadRepository;
        }
        public IActionResult Index()
        {
            //Customer customer = new Customer()
            //{
            //    firstName = FakeData.NameData.GetFirstName(),
            //    lastName = FakeData.NameData.GetSurname(),
            //    ePosta = FakeData.NetworkData.GetEmail(),
            //    city = FakeData.PlaceData.GetCity(),
            //    town = FakeData.PlaceData.GetStreetName(),
            //    phoneNumber = FakeData.PhoneNumberData.GetPhoneNumber(),
            //    gender = FakeData.BooleanData.GetBoolean(),
            //    createdDate = DateTime.UtcNow
            //};
           
            //_writeCustomerRepository.AddAsync(customer);
            ////_writeCustomerRepository.SaveAsync();
            return View();
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(VM_Create_Customer model)
        {
            //var customer = TypeConversion.Conversion<VM_Create_Customer, Customer>(model);
            //customer.createdDate = DateTime.Now;
            //isOk = await _writeCustomerRepository.AddAsync(customer);
            //await _writeCustomerRepository.SaveAsync();
            return View();
        }

        public IActionResult ListCustomers()
        {//  var customers = _readCustomerRepository.GetAll(false).ToList();
        //   List<VM_List_Customer> models = new List<VM_List_Customer>();
        //   foreach (var customer in customers)
        //    {
        //        var model = new VM_List_Customer
        //        {
        //            createdDate = customer.createdDate,
        //            firstName = customer.firstName,
        //            lastName = customer.lastName,
        //            phoneNumber = customer.phoneNumber,
        //            city = customer.city,
        //            town = customer.town,
        //            ID = customer.ID,
        //            ePosta = customer.ePosta,
        //            gender = customer.gender,
        //        };
        //        models.Add(model);
        //    }
             return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(VM_Details_Customer model)
        {
            //var customer = await _readCustomerRepository.GetByIdAsync(model.customer.ID);
            if (model.customer != null)
            {
               var customer = TypeConversion.Conversion<VM_List_Customer, Customer>(model.customer);
                isOk = _writeCustomerRepository.Update(customer);
               await _writeCustomerRepository.SaveAsync();
            }
           

            return RedirectToAction("ListCustomers");

        }

        public async Task<IActionResult> DetailCustomer(int id)
       {
            //Customer customer = await _readCustomerRepository.GetByIdAsync(id);
            //List<Product> products = _readProductRepository.GetWhere(p=> p.customer == customer).ToList();
           
            //customer.products = new List <Product>();
            //VM_List_Customer mCustomer = new VM_List_Customer
            //{
            //    createdDate = customer.createdDate,
            //    firstName = customer.firstName,
            //    lastName = customer.lastName,
            //    phoneNumber = customer.phoneNumber,
            //    city = customer.city,
            //    town = customer.town,
            //    ID = customer.ID,
            //    ePosta = customer.ePosta,
            //    gender = customer.gender,
            //};
            //List<VM_List_Product> mProducts = new();
            //if(products.Count > 0)
            //{
            //    foreach(var product in products) {

            //        VM_List_Product m = new VM_List_Product
            //        {
            //            createdDate = product.createdDate,
            //            ID = product.ID,
            //            name = product.name,
            //            description = product.description
            //        };
            //        mProducts.Add(m);
            //    }
            //}
            //VM_Details_Customer model = new VM_Details_Customer
            //{
            //    customer = mCustomer,
            //    products = mProducts
            //};
            return View();
        }
        
        public async Task<IActionResult> DeleteCustomer(int id)
        {
        //    isOk= await _writeCustomerRepository.RemoveAsync(id);
        //    await _writeCustomerRepository.SaveAsync();
            return RedirectToAction("ListCustomers");
        }

    }
}
