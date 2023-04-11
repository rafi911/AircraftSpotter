using AircraftSpotter.Api.models;
using AircraftSpotter.Domain.Entities;
using AircraftSpotter.Infrastructure.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AircraftSpotter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftSightingController : ControllerBase
    {
        private readonly IAircraftSightingService _service;
        private readonly IMapper _mapper;

        public AircraftSightingController(IAircraftSightingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sightings = await _service.GetAircraftSightingsAsync();
            var sightingDtos = _mapper.Map<IEnumerable<AircraftSightingDto>>(sightings);
            return Ok(sightingDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sighting = await _service.GetAircraftSightingAsync(id);
            if (sighting == null)
            {
                return NotFound();
            }

            var sightingDto = _mapper.Map<AircraftSightingDto>(sighting);
            return Ok(sightingDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AircraftSightingDto sightingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sighting = _mapper.Map<AircraftSighting>(sightingDto);
            var addedSighting = await _service.AddAircraftSightingAsync(sighting);
            var addedSightingDto = _mapper.Map<AircraftSightingDto>(addedSighting);

            return CreatedAtAction(nameof(Get), new { id = addedSightingDto.Id }, addedSightingDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AircraftSightingDto sightingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var aircraftSighting = _mapper.Map<AircraftSighting>(sightingDto);
                aircraftSighting.Id = id;
                await _service.UpdateAircraftSightingAsync(id, aircraftSighting);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAircraftSightingAsync(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            var sightings = await _service.SearchAircraftSightingsAsync(query);
            var sightingDtos = _mapper.Map<IEnumerable<AircraftSightingDto>>(sightings);
            return Ok(sightingDtos);
        }
    }
}
