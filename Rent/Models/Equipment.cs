using System;
using System.Collections.Generic;

#nullable disable

namespace Rent.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            Services = new HashSet<Service>();
        }

        public int EquipmentId { get; set; }
        public string EquiomentName { get; set; }
        public int ParameterId { get; set; }

        public virtual Parameter Parameter { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
