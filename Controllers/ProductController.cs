using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VoloShop.Models;

namespace VoloShop.Controllers
{
    public class ProductController : Controller
    {
        private ShopDBContext dbContext;
        public ProductController(ShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult ShopProducts()
        {
            var Sub = dbContext.SubCategories.ToList();
            ViewBag.SubCategory = Sub;
            var Cat = dbContext.ShopCategories.Where(x => x.ShopId.ToString() == HttpContext.Session.GetString("shopid")).ToList(); 
            ViewBag.ShopCategory = Cat;
            var pro = dbContext.ShopProducts.Where(x => x.SubCategoryId.ToString() == HttpContext.Session.GetString("shopid")).ToList();
            ViewBag.Products = pro;
            return View();
        }
        public IActionResult GetSubcat(string cid)
        {
            var Sub = dbContext.SubCategories.Where(x => x.CategoryId.ToString() == cid).ToList();
            ViewBag.SubCategory = Sub;
            var pro = dbContext.ShopProducts.Where(x => x.SubCategoryId.ToString() == cid).ToList();
            ViewBag.Products = pro;
            return View("Subdropdown");
        }

        public IActionResult GetSubcat1(string cid)
        {
            var Sub = dbContext.SubCategories.Where(x => x.CategoryId.ToString() == cid).ToList();
            ViewBag.SubCategory = Sub;
            var pro = dbContext.ShopProducts.Where(x => x.SubCategoryId.ToString() == cid).ToList();
            ViewBag.Products = pro;
            return View("Subdropdown1");
        }
        public IActionResult GetProcat(string sid)
        {
            //var Sub = dbContext.SubCategories.Where(x => x.CategoryId.ToString() == sid).ToList();
            //ViewBag.SubCategory = Sub;
            var pro = dbContext.ShopProducts.Where(x => x.SubCategoryId.ToString() == sid).ToList();
            ViewBag.Products = pro;
            return View("Producttable");
        }

        [HttpPost]
        public IActionResult ShopProducts(ShopProduct Pro , IFormFile Pic)
        {
            if (Pic != null && Pic.Length > 0)
            {
                var fileName = Path.GetFileName(Pic.FileName);
                var filePath = Path.Combine("wwwroot/ProPic", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Pic.CopyTo(fileStream);
                }
                Pro.Pic = fileName;
            }
            dbContext.ShopProducts.Add(Pro);
            dbContext.SaveChanges();
            return RedirectToAction("ShopProducts");
        }
    }
}
