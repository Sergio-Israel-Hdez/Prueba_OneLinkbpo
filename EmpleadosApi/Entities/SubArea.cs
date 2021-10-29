using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class SubArea
    {
        public int IdSubArea { get; set; }
        public int? IdArea { get; set; }
        public string NombreSubArea { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
    }
}
