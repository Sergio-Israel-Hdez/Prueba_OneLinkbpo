using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public int? IdDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? IdArea { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual TipoDocumento IdDocumentoNavigation { get; set; }
    }
}
