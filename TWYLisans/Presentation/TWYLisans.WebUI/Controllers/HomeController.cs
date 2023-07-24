using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TWYLisans.Application.Repositories;
using TWYLisans.Application.ViewModels.Products;
using TWYLisans.Domain.Entities;
using TWYLisans.WebUI.Models;

namespace TWYLisans.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public HomeController(IProductWriteRepository productWriteRepository , IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository; 
            _productWriteRepository = productWriteRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(VM_Create_Product model)
        //{
        //   // Product product = TypeConversion.Conversion<VM_Create_Product,Product>(model);
        //   // product.createdDate = DateTime.Now;
        //   // bool isAdded = await _productWriteRepository.AddAsync(product);
        //   //await  _productWriteRepository.SaveAsync();
        //    //if(!isAdded)
        //    //{
        //        var message = new AlertMessage()
        //        {
        //            message = $"{model.name} ürününz eklenemedi",
        //            alertType = "danger"

        //        };
        //        TempData["message"] = JsonConvert.SerializeObject(message);
                
            
        //    if (!ModelState.IsValid)
        //    {
        //        var msg = ModelState.ToList();             
        //    }
          
        //    return View();
        //}
       
     
    }
}