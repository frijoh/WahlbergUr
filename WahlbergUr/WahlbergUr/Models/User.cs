using System.ComponentModel.DataAnnotations;

namespace WahlbergUr.Models
{
    public class User
    {
       // public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter firstname")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 25")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter lastname")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 25")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 40")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter postal code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 40")]
        public string City { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Please enter personalnumber(id) yymmdd-nnnn")]
        public string IdNumber { get; set; }
        
        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required (ErrorMessage = "Please enter username")]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 40")]
        public string UserName { get; set; }

        [Required (ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
