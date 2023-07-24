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
        public IActionResult Index()
        {
            return View();
        }

    }
}