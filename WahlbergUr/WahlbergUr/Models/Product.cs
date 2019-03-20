using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WahlbergUr.Models
{
    public class Product
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [Required]
        [Display(Name = "Produktens Id")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Produktens namn")]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Produktens pris")]
        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal ProductPrice { get; set; }

        [Required]
        [Display(Name = "Produktens information")]
        [StringLength(1000)]
        public string ProductInformation { get; set; }

        [Required]
        [Display(Name = "Produktens Url")]
        public string ProductUrl { get; set; }
    }
}
