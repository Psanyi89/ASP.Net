using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
   public class Customer
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }
        public string States { get; set; }
        public string Zipcode { get; set; }
        public string Settlement { get; set; }
        public string Addresses { get; set; }
        public DateTime Modified { get; set; }

    }
}
