using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
#nullable disable

namespace Vehicle_System_API.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
