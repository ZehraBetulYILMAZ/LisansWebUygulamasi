using Microsoft.AspNetCore.Mvc;
using TWYLisans.Application.ViewModels.Products;

namespace TWYLisans.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(VM_Create_Product model)
        {
            return View();
        }
        public IActionResult ListProduct()
        {
            return View();
        }
        public IActionResult ProductDetails()
        {
            return View();
        }
        public IActionResult ProductUpdate()
        {
            return RedirectToAction("ProductDetails");
        }
        public IActionResult ProductDelete()
        {
            return RedirectToAction("ProductDetails");
        }
        public IActionResult LicenceDetails()
        {
            return View();
        }
        public IActionResult CreateLicence()
        {
            return View();
        }
    }
}
