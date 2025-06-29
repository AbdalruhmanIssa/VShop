using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VShop.Data;
using VShop.Models;

namespace VShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
       ApplicationDBContext Context=new ApplicationDBContext();
      
        public IActionResult Index()
        {
            ViewBag.Catigories = Context.Categories.ToList();
            
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
     

        public IActionResult Delete(int id)
        {
            var category = Context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null)
            {
                return RedirectToAction("Index");
            }

            Context.Categories.Remove(category);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
