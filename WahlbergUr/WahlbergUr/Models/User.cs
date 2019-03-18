using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WahlbergUr.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string PersonalIdNumber { get; set; }

        [NotMapped]
        public List<string> Roles { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string DatabaseId { get; set; }

        public User() : base()
        {
            this.Roles = new List<string>();
        }
    }
}
