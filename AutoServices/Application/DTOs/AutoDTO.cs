using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class AutoDTO
    {
        public Guid AutoId { get; set; }
        public string AutoColor { get; set; }
        public int AutoAnioFabricacion { get; set; }
        public string AutoNroPlaca { get; set; }
        public int AutoNroAsientos { get; set; }
        public string AutoMecanico { get; set; }
        public string AutoFull { get; set; }
        public Guid MarcaId { get; set; }

    }
}
