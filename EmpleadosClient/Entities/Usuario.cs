using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        [DisplayName("Usuario")]
        public string Usuario1 { get; set; }
        public string Password { get; set; }
    }
}
