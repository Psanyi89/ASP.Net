using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace WebShop.Models
{
    public class Customers
    {

        [Display(Name ="Username")]
        [StringLength(50,MinimumLength =5)]
        [RegularExpression("^[a-zA-Z0-9]+$",ErrorMessage ="Username can contains only alphabets and numbers.")]
        [Required(ErrorMessage ="Username required")]
        [Remote("IsUsernameSigned", "Account", HttpMethod = "POST", ErrorMessage = "Username already in use.")]
        public string Username { get; set; }
        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First name can contains only alphabets.")]
        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "First name required")]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last name can contains only alphabets.")]
        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Last name required")]
        public string Lastname { get; set; }
        [Display(Name ="Phonenumber")]
        [Phone()]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Please enter a valid phonenumber")]
        [RegularExpression("^[0-9]+$", ErrorMessage ="It's not a valid phonenumber format")]
        [StringLength(13,MinimumLength =10)]
        [Required(ErrorMessage = "Phonenumber required")]
        public string Phonenumber { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        [StringLength(50, MinimumLength = 5)]
        [Required(ErrorMessage = "Email address required")]
        [Remote("IsEmailSigned", "Account", HttpMethod = "POST", ErrorMessage = "Email already in use.")]
        public string Email { get; set; }
        [Display(Name = "Confirm Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        [Compare("Email",ErrorMessage ="Emails don't match.")]
        [Required(ErrorMessage ="Confirm Email address required")]
        public string Confirmemail { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8)]
        [Required(ErrorMessage = "Password required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}",
        ErrorMessage = @"Password must contain at least 1 lowercase, an uppercase letter,
a number, one special character, and must be eight characters or longer.")]
        public string Passwd { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Passwd",ErrorMessage ="Passwords don't match")]
        [Required(ErrorMessage ="Confirm password required")]
        public string Confirmpasswd { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date,ErrorMessage ="Invalid date format")]
        [Required(ErrorMessage ="Date of Birth required")]
        public DateTime Birthdate { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country required")]
        public string Country { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage ="Province required")]
        public string States { get; set; }
        [Display(Name ="City")]
        [Required(ErrorMessage ="City required")]
        public string Settlement { get; set; }
        [Display(Name ="PostCode")]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage ="PostCode required")]
        public  string Zipcode { get; set; }
        [Display(Name ="Address")]
        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage ="Address required")]
        public string Addresses { get; set; }
        

    }
}