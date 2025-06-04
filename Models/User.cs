using System.ComponentModel.DataAnnotations;

namespace VoloShop.Models
{
    public class User
    {
        [Key]   
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string PasswordConfirmed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
