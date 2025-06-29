using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VShop.Data;
using VShop.Models;
using VShop.Services;

namespace VShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();

        public IActionResult Index()
        {
            var products = context.Products.ToList();
        
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Catigories=context.Categories.ToList();
        
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product request, IFormFile Image)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = context.Categories.ToList();
                return View(request);
            }
            var imageService = new ImageService();
            string fileName = imageService.UploadImage(Image);
            request.Image = fileName;
            context.Products.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            ViewBag.Catigories = context.Categories.ToList();

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product request, IFormFile? image)
        {
            var exitingProduct = context.Products.AsNoTracking().FirstOrDefault(p => p.Id == request.Id); ;
            if (image is not null)
            {
                var imageService = new ImageService();
                string fileName = imageService.UploadImage(image);
                request.Image = fileName;
                imageService.DeleteImage(exitingProduct.Image);
            }
            else
            {
                request.Image = exitingProduct.Image;
            }

            context.Products.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            var imageService = new ImageService();
            imageService.DeleteImage(product.Image);

            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
