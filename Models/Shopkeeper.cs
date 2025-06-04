using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoloShop.Models
{
    public class Shopkeeper
    {
        [Key]
        public int ShopId { get; set; }
        public string ShopKeeperName {  get; set; }    
        public string ShopName { get; set; }
        public string Pic { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessType { get; set; }
        public string GSTNumber { get; set; }
        public string BankAccount { get; set; }
        public int AdharNumber { get; set; }
        public int PanNumber { get; set; }
        public string PaymentMethod { get; set; }
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }
       
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        
        

        public string Status { get; set; } = "Not Verified";
        public double Latitude { get; set; } 
        public double Longitude { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
