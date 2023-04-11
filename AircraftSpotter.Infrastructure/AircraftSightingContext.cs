using AircraftSpotter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSpotter.Infrastructure
{
    public class AircraftSightingContext: DbContext
    {
        public AircraftSightingContext(DbContextOptions<AircraftSightingContext> options)
        : base(options)
        {
        }
        public DbSet<AircraftSighting> AircraftSightings { get; set; }
    }
}
