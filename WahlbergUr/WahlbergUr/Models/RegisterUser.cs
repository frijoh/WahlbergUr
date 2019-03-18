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
        [StringLength(30, ErrorMessage = "{0} måste vara minst {2} och max {1} tecken långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta Lösenord")]
        [Compare("Password", ErrorMessage = "Lösenordet och det bekräftade lösenordet är olika!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Förnamn")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Längden måste vara mellan 2 och 25")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Efternamn")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Längden måste vara mellan 2 och 25")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Användarnamn")]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Längden måste vara mellan 2 och 40")]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Längden måste vara mellan 2 och 40")]
        [Display(Name = "Adress")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Postnummer")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Fyll i postnummer")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Stad")]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Längden måste vara mellan 2 och 40")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Personnummer")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Fyll i personnummer yymmdd-nnnn")]
        public string PersonalIdNumber { get; set; }
    }
}
