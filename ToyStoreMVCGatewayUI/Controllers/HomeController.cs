using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToyStoreMVCGatewayUI.Models;
using ToyStoreMVCGatewayUI.Repositories;

namespace ToyStoreMVCGatewayUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index(string sterm = "", int categoryId = 0)
        {
            IEnumerable<Product> products = await _homeRepository.GetProducts(sterm, categoryId);
            IEnumerable<Category> categories = await _homeRepository.Categories();
            ProductDisplayModel productModel = new ProductDisplayModel
            {
                Products = products,
                Categories = categories,
                STerm = sterm,
                CategoryId = categoryId
            };
            return View(productModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
