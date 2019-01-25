using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TMarca
    {
        public TMarca()
        {
            TAuto = new HashSet<TAuto>();
        }

        public Guid MarcaId { get; set; }
        public string MarcaNombre { get; set; }

        public ICollection<TAuto> TAuto { get; set; }
    }
}
