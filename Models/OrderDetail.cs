using System.ComponentModel.DataAnnotations;

namespace VoloShop.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }       // Unique identifier for the order detail
        public int OrderId { get; set; }             // Reference to the OrderId (relates to ProductOrder)
        public int ProductId { get; set; }           // The product being ordered
        public string ProductName { get; set; }      // Name of the product
        public decimal Price { get; set; }           // Price of the product
        public int Quantity { get; set; }            // Quantity of the product in the order
      

      
    }
}
