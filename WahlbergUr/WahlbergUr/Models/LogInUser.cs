using System.ComponentModel.DataAnnotations;

namespace WahlbergUr.Models
{
    public class LogInUser
    {
        [Required]
        [Display(Name = "Användarnamn")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
