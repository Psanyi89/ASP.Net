using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class CustomerList
    {
       

        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:d}")]
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }
        public string States { get; set; }
        public string Settlement { get; set; }
        public string Zipcode { get; set; }
        public string Addresses { get; set; }
        public DateTime Modified { get; set; }
    }
}