using System;
using System.Collections.Generic;

#nullable disable

namespace Rent.Models
{
    public partial class Parameter
    {
        public Parameter()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int ParameterId { get; set; }
        public int? BrandId { get; set; }
        public int? LevelId { get; set; }
        public string Style { get; set; }
        public string Bracing { get; set; }
        public float? Length { get; set; }
        public float? Weight { get; set; }
        public float? Size { get; set; }
        public string Statues { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
