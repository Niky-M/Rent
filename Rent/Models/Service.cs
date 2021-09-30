using System;
using System.Collections.Generic;

#nullable disable

namespace Rent.Models
{
    public partial class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int? EquipmentId { get; set; }
        public int? OrderId { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Order Order { get; set; }
    }
}
