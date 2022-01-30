using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Vehicle_System_API.Models
{
    public partial class Company
    {
        public Company()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Company name is required!")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Company name is required!")]
        public string CompanyLocation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
