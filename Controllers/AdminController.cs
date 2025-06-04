using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoloShop.Models;

namespace VoloShop.Controllers
{
    public class AdminController : Controller
    {
        private ShopDBContext dbContext;
        public AdminController(ShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
     
        public IActionResult Admindas()
        {
            return View();
        }
        public IActionResult Manageuser()
        {
            var log = dbContext.Shopkeepers.ToList();
            return View(log);
        }
        public IActionResult User1()
        {
            var log = dbContext.Shopkeepers.ToList();
            return View(log);
        }
        public IActionResult Deletdetail(int ShopId)
        {
            var del = dbContext.Shopkeepers.SingleOrDefault(x => x.ShopId == ShopId);
            dbContext.Shopkeepers.Remove(del);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}
