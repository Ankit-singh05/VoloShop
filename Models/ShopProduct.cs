using System.ComponentModel.DataAnnotations;

namespace VoloShop.Models
{
    public class ShopProduct
    {
        [Key]
        public int ProductId { get; set; }           // Unique identifier for the product
      
        public string ProductName { get; set; }      // Name of the product (e.g., 'Smartphone', 'T-shirt')
        public string Description { get; set; }      // A detailed description of the product
        public decimal Price { get; set; }           // Price of the product
        public string Pic { get; set; }
        //public int ShopId { get; set; }
        //public Shopkeeper Shopkeeper { get; set; }
        public int StockQuantity { get; set; }       // The quantity available in stock
       
        public int SubCategoryId { get; set; }          // The category ID the product belongs to (foreign key to Category)
        public string Brand { get; set; }            // Brand of the product (optional)
       
        public DateTime DateAdded { get; set; }      // Date when the product was added to the shop
        public bool IsActive { get; set; }           // Whether the product is active or discontinued

    }
}
