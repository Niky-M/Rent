using System;
using System.Collections.Generic;

#nullable disable

namespace Rent.Models
{
    public partial class Level
    {
        public Level()
        {
            Parameters = new HashSet<Parameter>();
        }

        public int LevelId { get; set; }
        public string LevelName { get; set; }

        public virtual ICollection<Parameter> Parameters { get; set; }
    }
}
