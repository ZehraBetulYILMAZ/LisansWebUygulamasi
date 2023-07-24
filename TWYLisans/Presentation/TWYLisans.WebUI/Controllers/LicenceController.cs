using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TWYLisans.Application.Repositories;
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
        bool isOk = false;
        public LicenceController(IProductReadRepository productReadRepository,
         ILicenceReadRepository licenceReadRepository, ILicenceWriteRepository licenceWriteRepository)
        {
            _readProductRepository = productReadRepository;
            _readLicenceRepository = licenceReadRepository;
            _writeLicenceRepository = licenceWriteRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateLicence(int id) 
        {
            VM_ProductsLicence m = new();
            var products = _readProductRepository.GetWhere(p=> p.active==true,false).Include(x=> x.category).ToList();
            if(products.Count > 0)
            {
                foreach(var product in products)
                {
                    VM_List_Product mProdcut = (VM_List_Product)product;
                    m.products.Add(mProdcut);
                }
            }
            m.licences.customerId= id;
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
    }
}
