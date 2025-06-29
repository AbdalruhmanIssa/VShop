using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VShop.Data;
using VShop.Models;

namespace VShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDBContext _dbContext=new ApplicationDBContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ViewData["Catigoties"]  = _dbContext.Categories.ToList();so we can show multiple data in one page like cats and prods
           ViewBag.Catigories= _dbContext.Categories.ToList();
           ViewBag.Products= _dbContext.Products.ToList();
            return View();
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
