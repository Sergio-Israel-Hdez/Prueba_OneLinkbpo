using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdDocumento { get; set; }
        public string NombreDocumento { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
