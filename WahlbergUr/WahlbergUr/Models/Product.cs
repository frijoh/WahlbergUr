using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WahlbergUr.Models
{
    public class Product
    {
        //[JsonProperty(PropertyName = "_self")]
        //public string SelfLink { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

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

        //public object Type { get; internal set; }
    }
}
