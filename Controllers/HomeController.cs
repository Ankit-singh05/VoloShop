using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VoloShop.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace VoloShop.Controllers
{
    public class HomeController : Controller
    {
        private ShopDBContext dbContext;
        public HomeController(ShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Shopkeeper b)
        {
            var log = dbContext.Shopkeepers.Where(x => x.Email == b.Email && x.Password == b.Password).FirstOrDefault();
            if (log != null)
            {
                HttpContext.Session.SetString("mysession", b.Email);
                HttpContext.Session.SetString("shopid", log.ShopId.ToString());
           
                return View("Dashboard");
            }
            else
            {
                return View();
            }
        }
        
        public IActionResult SignUP()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUP(Shopkeeper a, IFormFile Pic)
        {
             a.Status = "Not Varified";
            if (Pic != null && Pic.Length > 0)
            {
                var fileName = Path.GetFileName(Pic.FileName);
                var filePath = Path.Combine("wwwroot/ShopPic", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Pic.CopyTo(fileStream);
                }
                a.Pic = fileName;
            }
            dbContext.Shopkeepers.Add(a);
                 dbContext.SaveChanges();
            
             return RedirectToAction("Index");

           
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("mysession");
            return RedirectToAction("Index");
        }
        public IActionResult Dashboard()
        {
            //// 1. Ensure the shopkeeper is logged in
            //var shopIdString = HttpContext.Session.GetString("mysession");
            //if (string.IsNullOrEmpty(shopIdString) || !int.TryParse(shopIdString, out var currentShopId))
            //{
            //    return RedirectToAction("Index");  // or your login action
            //}

            //// 2. Load only this shop’s products
            //var myProducts = dbContext.ShopProducts
            //    .Where(p => p.ShopId == currentShopId)
            //    .ToList();

            //// 3. (Optional) load the shopkeeper’s info for display
            //var shopkeeper = dbContext.Shopkeepers
            //    .SingleOrDefault(s => s.ShopId == currentShopId);

            //ViewBag.ShopkeeperName = shopkeeper?.ShopName ?? "My Shop";
            //ViewBag.Products = myProducts;

            //var pro = '';
            List<ProductOrder> orders = new List<ProductOrder>
    {
        new ProductOrder
        {
            CustomerId = 1,
            OrderDate = DateTime.Parse("2025-05-30T19:52:13.8402158"),
            ShippingAddress = "VN",
            Status = "Pending"
            
        },
        new ProductOrder
        {
            CustomerId = 1,
            OrderDate = DateTime.Parse("2025-05-30T19:53:41.7654370"),
            ShippingAddress = "VN",
            Status = "Pending"
            
        }
    };

            ViewBag.Pro = orders;
            return View();
        }

        public IActionResult Profile()
        {
            var lo = dbContext.Shopkeepers.ToList();
            ViewBag.Shopkeepers = lo;
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
