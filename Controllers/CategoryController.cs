using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using VoloShop.Models;

namespace VoloShop.Controllers
{
    public class CategoryController : Controller
    {
        private ShopDBContext dbContext;
        public CategoryController(ShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult ShopCategory()
        {
            var log = dbContext.ShopCategories.Where(x=>x.ShopId.ToString()==HttpContext.Session.GetString("shopid")).ToList();
            ViewBag.ShopCategory = log;
            return View();
        }
        [HttpPost]
        public IActionResult ShopCategory(ShopCategory model, IFormFile Pic)
        {
            var sid = HttpContext.Session.GetString("shopid");
            model.ShopId =Convert.ToInt32(sid);
            //if (ModelState.IsValid)`
            //{
            if (Pic != null && Pic.Length > 0)
            {
                var fileName = Path.GetFileName(Pic.FileName);
                var filePath = Path.Combine("wwwroot/Image", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Pic.CopyTo(fileStream);
                }
                model.Pic = fileName;
            }
            // Save model to the database here
            dbContext.ShopCategories.Add(model);
            dbContext.SaveChanges();
            return RedirectToAction("Shopcategory");
            //}
            //return View(model);
        }
       
    }
}
