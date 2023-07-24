using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TWYLisans.Application.Repositories;
using TWYLisans.Application.ViewModels.Customers;
using TWYLisans.Application.ViewModels.Licences;
using TWYLisans.Application.ViewModels.Products;
using TWYLisans.Domain.Entities;
using TWYLisans.WebUI.Models;

namespace TWYLisans.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductReadRepository _readProductRepository;
        private readonly IProductWriteRepository _writeProductRepository;
        private readonly ICategoryReadRepository _readCategoryRepository;
        private readonly ICategoryWriteRepository _writeCategoryRepository;
        bool isOk = false;
        public ProductController(IProductReadRepository productReadRepository , IProductWriteRepository productWriteRepository,
         ICategoryReadRepository readCategoryRepository, ICategoryWriteRepository writecategoryRepository)
        {
            _readProductRepository = productReadRepository;
            _writeProductRepository = productWriteRepository;
            _readCategoryRepository = readCategoryRepository;
            _writeCategoryRepository = writecategoryRepository;
        }
        public IActionResult Index()
        { 
            return View();
        }
        public IActionResult CreateProduct()
        {
            VM_Create_Product model = new();
            var categories = _readCategoryRepository.GetAll(false).ToList();
            foreach (var category in categories)
            {
                VM_List_Category m = (VM_List_Category)category;
                model.categories.Add(m);
            }
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct(VM_Create_Product model)
        {

            AlertMessage msg = new AlertMessage();
            if (!ModelState.IsValid)
            {

                msg.message = "Product eklenemedi";
                msg.alertType = "danger";


                TempData["message"] = JsonConvert.SerializeObject(msg);
                return RedirectToAction("ListProduct");
            }
            Product product = (Product)model;
            isOk =await _writeProductRepository.AddAsync(product);
            await _writeProductRepository.SaveAsync();
            if (!isOk)
            {

                msg.message = $"{model.productName}  eklenemedi";
                msg.alertType = "danger";

                TempData["message"] = JsonConvert.SerializeObject(msg);
                return RedirectToAction("ListProduct");
            }
            msg.message = $"{model.productName}  eklendi";
            msg.alertType = "success";


            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("ListProduct");
        }
        public ActionResult ListProduct()
        {
            var products=_readProductRepository.GetWhere(p=> p.active==true,false).Include(c=>c.category).ToList();
            List<VM_List_Product> models = new();
            foreach (var product in products)
            {
                VM_List_Product m = (VM_List_Product)product;
                models.Add(m);
            }
            return View(models);
        }
        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _readProductRepository.GetByIdProductAsync(id);
            var categories = _readCategoryRepository.GetAll(false).ToList();
            VM_List_Product model = (VM_List_Product)product;
            foreach (var category in categories)
            {
                VM_List_Category m = (VM_List_Category)category;
                model.categories.Add(m);
            }
            return View(model);
        }
        public async Task<IActionResult> ProductUpdate(VM_List_Product model)
        {
            var category = await _readCategoryRepository.GetByIdAsync(model.categoryId);
            model.categoryName = category.categoryName;
            Product product = (Product)model;
            isOk = _writeProductRepository.UpdateProduct(product);
            await  _writeProductRepository.SaveAsync();
            AlertMessage msg = new AlertMessage();
            msg.message = isOk ? "Kayıt başarıyla güncelendi" : "Kayıt güncelenemedi";
            msg.alertType = isOk ? "success" : "danger";
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("ListProduct");
        }
        public IActionResult ProductDelete()
        {
            return RedirectToAction("ListProduct");
        }

        public async Task<IActionResult> CreateCategory(VM_Create_Product model)
        {
            if (model.categoryName != null)
            {
                Category category = new Category
                {
                    categoryName = model.categoryName,
                };
                isOk = await _writeCategoryRepository.AddAsync(category);
                await _writeCategoryRepository.SaveAsync();
            }
            AlertMessage msg = new AlertMessage();
            msg.message = isOk ? "Kategori başarıyla eklendi" : "Kategori eklenemedi";
            msg.alertType = isOk ? "success" : "danger";
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("CreateProduct");
        }
    }
}
