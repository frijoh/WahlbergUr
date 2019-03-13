using System.ComponentModel.DataAnnotations;

namespace WahlbergUr.Models
{
    public class LogInUser
    {
        [Required(ErrorMessage = "Please enter username")]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 40")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
