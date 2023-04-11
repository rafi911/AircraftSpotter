using AircraftSpotter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSpotter.Infrastructure.Services
{
    public interface IAircraftSightingService
    {
        Task<IEnumerable<AircraftSighting>> GetAircraftSightingsAsync();
        Task<AircraftSighting?> GetAircraftSightingAsync(int id);
        Task<AircraftSighting> AddAircraftSightingAsync(AircraftSighting sighting);
        Task UpdateAircraftSightingAsync(int id, AircraftSighting sighting);
        Task DeleteAircraftSightingAsync(int id);
        Task<IEnumerable<AircraftSighting>> SearchAircraftSightingsAsync(string query);
    }
}
