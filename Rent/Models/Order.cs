using System;
using System.Collections.Generic;

#nullable disable

namespace Rent.Models
{
    public partial class Order
    {
        public Order()
        {
            Services = new HashSet<Service>();
        }

        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public string StuffId { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public float Price { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
