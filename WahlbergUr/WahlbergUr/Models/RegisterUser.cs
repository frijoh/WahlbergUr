using System.ComponentModel.DataAnnotations;

namespace WahlbergUr.Models
{
    public class RegisterUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 25")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 25")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User name")]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 40")]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 40")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Please enter postalcode")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 40")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Personal IdNumber")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Please enter personalnumber(id) yymmdd-nnnn")]
        public string PersonalIdNumber { get; set; }
    }
}
