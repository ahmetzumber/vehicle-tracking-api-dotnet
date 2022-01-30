using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
#nullable disable

namespace Vehicle_System_API.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            TrackingDetails = new HashSet<TrackingDetail>();
        }

        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public int VehicleTypeId { get; set; }
        public int CompanyId { get; set; }
        public int ModalYear { get; set; }
        public int Price { get; set; }

        public virtual Company Company { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        [JsonIgnore]
        public virtual ICollection<TrackingDetail> TrackingDetails { get; set; }
    }
}
