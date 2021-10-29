using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Area
    {
        public Area()
        {
            Empleados = new HashSet<Empleado>();
            SubAreas = new HashSet<SubArea>();
        }

        public int IdArea { get; set; }
        public string NombreArea { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<SubArea> SubAreas { get; set; }
    }
}
