using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data
{
    public class Author
    {

        public string AuthorId { get; set; }
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }       
        [StringLength(20,ErrorMessage ="City name cannot be longer than 20 characters")]
        public string City { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string EmailAddress { get; set; }
        [Range(1000,int.MaxValue,ErrorMessage ="Salary should be greater than $1000.")]
        public int Salary { get; set; }

    }
}