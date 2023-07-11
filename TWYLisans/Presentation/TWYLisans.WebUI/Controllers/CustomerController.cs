using Microsoft.AspNetCore.Mvc;
using TWYLisans.Application.Repositories;
using TWYLisans.Application.ViewModels.Customer;
using TWYLisans.Domain.Entities;
using TWYLisans.Infrastructure;

namespace TWYLisans.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IReadCustomerRepository _readCustomerRepository;
        private readonly IWriteCustomerRepository _writeCustomerRepository;
        bool isAdded = false;
        public CustomerController(IReadCustomerRepository readCustomerRepository, IWriteCustomerRepository writeCustomerRepository)
        {

            _readCustomerRepository = readCustomerRepository;
            _writeCustomerRepository = writeCustomerRepository;
        }
        public async Task<IActionResult> Index()
        {
            Customer customer = new Customer()
            {
                firstName = FakeData.NameData.GetFirstName(),
                lastName = FakeData.NameData.GetSurname(),
                ePosta = FakeData.NetworkData.GetEmail(),
                city = FakeData.PlaceData.GetCity(),
                town = FakeData.PlaceData.GetStreetName(),
                phoneNumber = FakeData.PhoneNumberData.GetPhoneNumber(),
                gender = FakeData.BooleanData.GetBoolean(),
                createdDate = DateTime.UtcNow
            };
           
            _writeCustomerRepository.AddAsync(customer);
            _writeCustomerRepository.SaveAsync();
            return View();
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(VM_Create_Customer model)
        {
            var customer = TypeConversion.Conversion<VM_Create_Customer, Customer>(model);
            customer.createdDate = DateTime.Now;
            isAdded = await _writeCustomerRepository.AddAsync(customer);
            _writeCustomerRepository.SaveAsync();
            return View();
        }

        public IActionResult ListCustomers()
        {
            return View();
        }
        public IActionResult UpdateCustomer()
        {
            return RedirectToAction("DetailCustomer");
        }
        public IActionResult DetailCustomer()
        {
            return View();
        }
        public IActionResult DeleteCustomer()
        {
            return RedirectToAction("ListCustomers");
        }

    }
}
