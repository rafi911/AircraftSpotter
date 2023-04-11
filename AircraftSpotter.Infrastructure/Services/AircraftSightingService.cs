using AircraftSpotter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSpotter.Infrastructure.Services
{
    public class AircraftSightingService : IAircraftSightingService
    {
        private readonly AircraftSightingContext _context;

        public AircraftSightingService(AircraftSightingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// return aircraft list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AircraftSighting>> GetAircraftSightingsAsync()
        {
            return await _context.AircraftSightings.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// retun an aircraft by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AircraftSighting?> GetAircraftSightingAsync(int id)
        {
            return await _context.AircraftSightings.FindAsync(id);
        }

        /// <summary>
        /// Store an aircraft
        /// </summary>
        /// <param name="sighting"></param>
        /// <returns></returns>
        public async Task<AircraftSighting> AddAircraftSightingAsync(AircraftSighting sighting)
        {
            _context.AircraftSightings.Add(sighting);
            await _context.SaveChangesAsync();
            return sighting;
        }

        /// <summary>
        /// Update an aircraft
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sighting"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAircraftSightingAsync(int id, AircraftSighting sighting)
        {
            var existingSighting = await _context.AircraftSightings.FindAsync(id);
            if (existingSighting == null)
            {
                throw new Exception("Aircraft sighting not found");
            }

            existingSighting.Make = sighting.Make;
            existingSighting.Model = sighting.Model;
            existingSighting.Registration = sighting.Registration;
            existingSighting.Location = sighting.Location;
            existingSighting.DateTimeSeen = sighting.DateTimeSeen;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete an aircraft
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAircraftSightingAsync(int id)
        {
            var sighting = await _context.AircraftSightings.FindAsync(id);
            if (sighting == null)
            {
                throw new Exception("Aircraft sighting not found");
            }

            _context.AircraftSightings.Remove(sighting);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Return aircrafts by query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AircraftSighting>> SearchAircraftSightingsAsync(string query)
        {
            var aircraftSightings = _context.AircraftSightings.AsQueryable();
            query = query.ToLower();

            if (!string.IsNullOrEmpty(query))
            {
                aircraftSightings = aircraftSightings.Where(s => s.Make.ToLower().Contains(query) ||
                                    s.Model.ToLower().Contains(query) || 
                                    s.Registration.ToLower().Contains(query)||
                                    s.Location.ToLower().Contains(query) ||
                                    s.Registration.ToLower().Contains(query));
            }

            return await aircraftSightings.ToListAsync();
        }
    }

}
