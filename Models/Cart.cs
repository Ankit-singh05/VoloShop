using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace VoloShop.Models
{
    public class Cart
    {

        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
