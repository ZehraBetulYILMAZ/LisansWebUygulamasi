using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Text;
using TWYLisans.Application.Repositories;
using TWYLisans.Application.ViewModels.Customers;
using TWYLisans.Application.ViewModels.Licences;
using TWYLisans.Domain.Entities;
using TWYLisans.WebUI.Models;

namespace TWYLisans.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IReadCustomerRepository _readCustomerRepository;
        private readonly IWriteCustomerRepository _writeCustomerRepository;
        bool isOk = false;
        public CustomerController(IReadCustomerRepository readCustomerRepository, IWriteCustomerRepository writeCustomerRepository , IProductReadRepository productReadRepository)
        {

            _readCustomerRepository = readCustomerRepository;
            _writeCustomerRepository = writeCustomerRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(VM_Create_Customer model)
        {
            AlertMessage msg = new AlertMessage();
            if (!ModelState.IsValid)
            {

                msg.message = "Müşteri eklenemedi";
                msg.alertType = "danger";


                TempData["message"] = JsonConvert.SerializeObject(msg);
                return View();
            }
            var customer = (Customer)model;
           
                string mail = model.mailaddress;

                // convert string to stream
                byte[] byteArray = Encoding.ASCII.GetBytes(mail);
                customer.mailaddress = byteArray;

            isOk = await _writeCustomerRepository.AddAsync(customer);
            await _writeCustomerRepository.SaveAsync();
            if (!isOk)
            {

                msg.message = $"{model.companyName}  eklenemedi";
                msg.alertType = "danger";

                TempData["message"] = JsonConvert.SerializeObject(msg);
                return View();
            }
            msg.message = $"{model.companyName}  eklendi";
                msg.alertType = "success";

         
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return View();
        }
        public IActionResult ListCustomers()
        {
            AlertMessage msg = new AlertMessage();
            var customers = _readCustomerRepository.GetWhere(c => c.active == true, false).Include(e => e.town).Include(c => c.town.city).ToList();
            if (customers == null || customers.Count<0)
            {
                msg.message = "Müşteriler Bulunamadı";
                msg.alertType = "danger";
                TempData["message"] = JsonConvert.SerializeObject(msg);
                return View("NoModel");
            }
            List<VM_List_Customer> models = new List<VM_List_Customer>();
            foreach (var customer in customers)
            {
                VM_List_Customer m = (VM_List_Customer)customer;
                models.Add(m);
            }
            return View(models);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(VM_Details_Customer model)
        {
            if (model.customer != null)
            {
                var customer = (Customer)model.customer;
                byte[] byteArray = Encoding.ASCII.GetBytes(model.customer.mailaddress);
                customer.mailaddress = byteArray;
                isOk = _writeCustomerRepository.UpdateCustomer(customer);
                await _writeCustomerRepository.SaveAsync();
            }
            AlertMessage msg = new AlertMessage();
            msg.message = isOk ? "Kayıt başarıyla güncelendi" : "Kayıt güncelenemedi"; 
            msg.alertType = isOk ? "success" : "danger";
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("ListCustomers");

        }

        public async Task<IActionResult> DetailCustomer(int id)
        { 
            AlertMessage msg = new AlertMessage();
            Customer customer = await _readCustomerRepository.GetByIdCustomerAsync(id);
            if(customer == null) {
                 msg.message = "Müşteri Bulunamadı";
                 msg.alertType = "danger";
                TempData["message"] = JsonConvert.SerializeObject(msg);
                return RedirectToAction("ListCustomers");
            }
            VM_List_Customer mCustomer = (VM_List_Customer)customer;
            //MemoryStream stream = new MemoryStream(customer.mailaddress);
            //StreamReader reader = new StreamReader(stream);
            //mCustomer.mailaddress = reader.ReadToEnd();
            List<VM_List_Licence> mLicence= new();
            if (customer.licences.Count > 0)
            {
                    foreach (var licence in customer.licences)
                    {
                       VM_List_Licence m = (VM_List_Licence)licence;
                        mLicence.Add(m);
                    }
            }

            VM_Details_Customer model = new VM_Details_Customer()
            {
                customer = mCustomer,
                licence = mLicence
            };
            return View(model);
        }
        
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            isOk=  _writeCustomerRepository.RemoveCustomer(id);
            await _writeCustomerRepository.SaveAsync();
            
            AlertMessage msg = new AlertMessage();
            msg.message = isOk ? "Kayıt başarıyla silindi" : "Kayıt Silinemedi";
            msg.alertType = isOk ? "success" : "danger";
            TempData["message"] = JsonConvert.SerializeObject(msg);

            
            return RedirectToAction("ListCustomers");
        }
        [HttpGet]
        public async Task<FileResult> ExportCustomersInExcel()
        {
            var customers = _readCustomerRepository.GetWhere(c => c.active == true, false).Include(e => e.town).Include(c => c.town.city).ToList();
            var filename = "customers.xlsx";
            return GenaretExcel(filename, customers);
        }
        private FileResult GenaretExcel(string filename , List<Customer> customers)
        {
            DataTable dataTable = new DataTable("Müşteriler");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id"),
                new DataColumn("companyName"),
                new DataColumn("ePosta"),
                new DataColumn("phoneNumber"),
                new DataColumn("townname"),
                new DataColumn("cityname"),
            });
            foreach (var customer in customers)
            {
                dataTable.Rows.Add(customer.ID,customer.companyName, customer.ePosta,customer.phoneNumber,customer.town.townname,customer.town.city.cityname);
            }
            using(XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using(MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return File(ms.ToArray(),"application/vnd.openxmlformats.officedocument.spreadsheetml.sheet",
                        filename);
                }
            }
        }
    }
}
