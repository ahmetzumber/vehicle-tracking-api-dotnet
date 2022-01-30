using System;
using System.Collections.Generic;

#nullable disable

namespace Vehicle_System_API.Models
{
    public partial class TrackingDetail
    {
        public int TrackingId { get; set; }
        public string TrackingLocation { get; set; }
        public DateTime TrackingDate { get; set; }
        public string TrackingDesc { get; set; }
        public int VId { get; set; }

        public virtual Vehicle VIdNavigation { get; set; }
    }
}
