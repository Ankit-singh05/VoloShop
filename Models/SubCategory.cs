using System.ComponentModel.DataAnnotations;

namespace VoloShop.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }       // Unique identifier for the subcategory
        public string SubCategoryName { get; set; }  // Name of the subcategory (e.g., 'Smartphones', 'Laptops')
        public string Description { get; set; }      // Description of the subcategory
        public int CategoryId { get; set; }          // Parent category id (to link to the parent ShopCategory)
        public string Pic { get; set; }

    }
}
