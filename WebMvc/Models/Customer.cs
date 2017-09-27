using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string Fname { get; set; }

        [DisplayName("Surname")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string Lnane { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "confirmPassword is Required")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

        [DisplayName("E-mail Address")]
        [Required(ErrorMessage = "Your E-mail Address is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Your Phone Number is Required")]
        public string PhoneNumber { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Are you Male Or Female")]
        public string Gender { get; set; }

        [DisplayName("ID Number")]
        [Required(ErrorMessage = "Your ID Number is Required")]
        public string IDNumber { get; set; }
    }
}