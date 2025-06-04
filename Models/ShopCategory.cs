using System.ComponentModel.DataAnnotations;

namespace VoloShop.Models
{
    public class ShopCategory
    {
        [Key]
        public int CategoryId { get; set; }           // Unique identifier for the category
        public string CategoryName { get; set; }      // Name of the category (e.g., 'Electronics', 'Clothing')
        public string Description { get; set; }       // Description of the category
        public int ShopId { get; set; }
        public string Pic { get; set; }

    }
}
