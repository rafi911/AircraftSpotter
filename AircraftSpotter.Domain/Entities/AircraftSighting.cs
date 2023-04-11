using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSpotter.Domain.Entities
{
    public class AircraftSighting
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Registration { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime DateTimeSeen { get; set; }
    }
}
