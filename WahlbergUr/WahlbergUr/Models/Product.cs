using System.ComponentModel.DataAnnotations;

namespace WahlbergUr.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal ProductPrice { get; set; }

        [Required]
        [StringLength(1000)]
        public string ProductInformation { get; set; }

        [Required]
        public string ProductUrl { get; set; }

        //public int Quantity { get; set; }
    }
}
