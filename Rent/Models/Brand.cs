using System;
using System.Collections.Generic;

#nullable disable

namespace Rent.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Parameters = new HashSet<Parameter>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Parameter> Parameters { get; set; }
    }
}
