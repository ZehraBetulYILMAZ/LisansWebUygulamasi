using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using TWYLisans.Application.Repositories;
using TWYLisans.Application.ViewModels.Customers;
using TWYLisans.Application.ViewModels.Licences;
using TWYLisans.Application.ViewModels.Products;
using TWYLisans.Domain.Entities;
using TWYLisans.WebUI.Models;

namespace TWYLisans.WebUI.Controllers
{
    public class LicenceController : Controller
    {
        private readonly IProductReadRepository _readProductRepository;
        private readonly ILicenceReadRepository _readLicenceRepository;
        private readonly ILicenceWriteRepository _writeLicenceRepository;
        private readonly IReadCustomerRepository _readCustomerRepository;
        bool isOk = false;
        public LicenceController(IProductReadRepository productReadRepository,
         ILicenceReadRepository licenceReadRepository, ILicenceWriteRepository licenceWriteRepository,
         IReadCustomerRepository readCustomerRepository)
        {
            _readProductRepository = productReadRepository;
            _readLicenceRepository = licenceReadRepository;
            _writeLicenceRepository = licenceWriteRepository;
            _readCustomerRepository = readCustomerRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateLicence(int ?id) 
        {
            VM_ProductsLicence m = new();
            var products = _readProductRepository.GetWhere(p=> p.active==true,false).Include(x=> x.category).ToList();
            var customers = _readCustomerRepository.GetWhere(c => c.active == true, false).Include(e => e.town).Include(c => c.town.city).ToList();
            if (products.Count > 0)
            {
                foreach(var product in products)
                {
                    VM_List_Product mProdcut = (VM_List_Product)product;
                    m.products.Add(mProdcut);
                }
            }
            if(customers.Count > 0)
            {
                foreach(var customer in customers)
                {
                    VM_List_Customer mCustomer = (VM_List_Customer)customer;
                    m.customers.Add(mCustomer);
                }
            }
            
            if(id != null)
            {
                m.licences.customerId = (int)id;
            }
                   
            return View(m);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLicence(VM_ProductsLicence model)
        {
            AlertMessage msg = new AlertMessage();
            if (!ModelState.IsValid)
            {

                msg.message = "Lisans eklenemedi";
                msg.alertType = "danger";


                TempData["message"] = JsonConvert.SerializeObject(msg);
                return RedirectToAction("index");
            }
            Licence licence = (Licence)model.licences;
            licence.active = true;
            licence.creationDate = DateTime.Now;
            isOk =  await _writeLicenceRepository.AddAsync(licence);
            await _writeLicenceRepository.SaveAsync();
            if (!isOk)
            {

                msg.message = $"{model.licences.licencekey}  eklenemedi";
                msg.alertType = "danger";

                TempData["message"] = JsonConvert.SerializeObject(msg);
                return RedirectToAction("index");
            }
            msg.message = $"{model.licences.licencekey}  eklendi";
            msg.alertType = "success";


            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("index");
        }

        public IActionResult ListLicence() 
        {
            var licences = _readLicenceRepository.GetWhere(l=>l.active == true, false).Include(e=> e.product).Include(x=> x.customer).ToList();
            List<VM_List_Licence> models = new();
            if(licences.Count > 0)
            {
                foreach (var l in licences)
                {
                    VM_List_Licence model = (VM_List_Licence)l;
                    models.Add(model);
                }
            }
            return View(models); 
        }

        public  async Task<IActionResult> DetailLicence(int id)
        {
            Licence licence = await _readLicenceRepository.GetByIdLicenceAsync(id);
            VM_List_Licence model = (VM_List_Licence) licence;
         
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLicence(VM_List_Licence model)
        {
            Licence licence = (Licence)model;
            isOk = _writeLicenceRepository.UpdateLicence(licence);
            await _writeLicenceRepository.SaveAsync();
            AlertMessage msg = new AlertMessage();
            msg.message = isOk ? "Kayıt başarıyla güncelendi" : "Kayıt güncelenemedi";
            msg.alertType = isOk ? "success" : "danger";
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("ListLicence");
        }
        public async Task<IActionResult> DeleteLicence(int id)
        {
            isOk = _writeLicenceRepository.RemoveLicence(id);
            await _writeLicenceRepository.SaveAsync();

            AlertMessage msg = new AlertMessage();
            msg.message = isOk ? "Kayıt başarıyla silindi" : "Kayıt Silinemedi";
            msg.alertType = isOk ? "success" : "danger";
            TempData["message"] = JsonConvert.SerializeObject(msg);


            return RedirectToAction("ListLicence");
        }
        public async Task<FileResult> ExportLicenceInExcel()
        {
            var licence = _readLicenceRepository.GetWhere(l => l.active == true, false).Include(e => e.product).Include(x => x.customer).ToList();
            var filename = "licences.xlsx";
            return GenaretExcel(filename, licence);
        }
        private FileResult GenaretExcel(string filename, List<Licence> licences)
        {
            DataTable dataTable = new DataTable("Lisanslar");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id"),
                new DataColumn("licencekey"),
                new DataColumn("creationDate"),
                new DataColumn("endingDate"),
                new DataColumn("companyName"),
                new DataColumn("productName"),
            });
            foreach (var licence in licences)
            {
                dataTable.Rows.Add(licence.ID, licence.creationDate,licence.endingDate,licence.customer.companyName, licence.product.productName);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats.officedocument.spreadsheetml.sheet",
                        filename);
                }
            }
        }
    }
}
