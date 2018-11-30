using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class CustomerLogin
    {
        [Display(Name ="Username")]
        [Required(ErrorMessage ="Username required")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        
        public bool Remember { get; set; }
    }
}