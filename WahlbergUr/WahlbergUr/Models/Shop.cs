using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WahlbergUr.Models
{
    public class Shop
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Från Dag")]
        public string FromDay { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Till Dag")]
        public string ToDay { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Lördag-Söndag")]
        public string Weekend { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Öppettid")]
        public string OpeningHours { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Stängningstid")]
        public string ClosingHours { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Stängt eller öppet på helgen")]
        public string IsClosed { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Postnummer")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Stad")]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        
        public string CustomerInformation { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Information")]
        public string ShopInformation { get; set; }
    }
}
