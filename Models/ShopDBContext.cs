using Microsoft.EntityFrameworkCore;

namespace VoloShop.Models
{
    public class ShopDBContext:DbContext
    {
        public ShopDBContext(DbContextOptions dbContext) : base(dbContext) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<ShopProduct> ShopProducts { get; set; }
        public DbSet<SubCategory> SubCategories{ get; set; }

        public DbSet<Shopkeeper> Shopkeepers{ get; set; }
        public DbSet<User> Users { get; set; }
    }
}
