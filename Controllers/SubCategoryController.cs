using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoloShop.Models;

namespace VoloShop.Controllers
{
    public class SubCategoryController : Controller
    {
        private ShopDBContext dbContext;
        public SubCategoryController(ShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult ShopSubCategory()
        {
            //var Sub = dbContext.SubCategories.ToList();
            //ViewBag.SubCategory = Sub;
            var Cat = dbContext.ShopCategories.Where(x => x.ShopId.ToString() == HttpContext.Session.GetString("shopid")).ToList();
            ViewBag.ShopCategory = Cat;
            return View();
        }

        public IActionResult GetSubcat(string cid)
        {
            var Sub = dbContext.SubCategories.Where(x=>x.CategoryId.ToString()==cid).ToList();
            ViewBag.SubCategory = Sub;
            return View("Subcattable");
        }


        [HttpPost]
        public IActionResult ShopSubCategory(SubCategory Sub, IFormFile Pic)
        {
            if (Pic != null && Pic.Length > 0)
            {
                var fileName = Path.GetFileName(Pic.FileName);
                var filePath = Path.Combine("wwwroot/Subcatpic", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Pic.CopyTo(fileStream);
                }
                Sub.Pic = fileName;
            }
            dbContext.SubCategories.Add(Sub);
            dbContext.SaveChanges();
            return RedirectToAction("ShopSubCategory");
        }
    }
}
