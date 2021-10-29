using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace Entities
{
    public partial class SubArea
    {
        public int IdSubArea { get; set; }
        public int? IdArea { get; set; }
        [DisplayName("Nombre SubArea")]
        public string NombreSubArea { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
    }
}
