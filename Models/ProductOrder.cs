using System.ComponentModel.DataAnnotations;

namespace VoloShop.Models
{
    public class ProductOrder
    {
        [Key]
        public int OrderId { get; set; }            // Unique identifier for the order
        public int CustomerId { get; set; }         // Unique identifier for the customer who placed the order
        public DateTime OrderDate { get; set; }     // The date when the order was placed
        public string ShippingAddress { get; set; } // Shipping address for the order
        public string Status { get; set; }          // Status of the order (e.g., Pending, Shipped, Delivered)
        public decimal TotalAmount { get; set; }    // Total amount for the entire order

       
       
    }
}
