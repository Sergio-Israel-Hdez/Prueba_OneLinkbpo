using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace Entities
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        [DisplayName("Documento")]
        public int? IdDocumento { get; set; }
        [DisplayName("Numero Documento")]
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DisplayName("Area")]
        public int? IdArea { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual TipoDocumento IdDocumentoNavigation { get; set; }
    }
}
