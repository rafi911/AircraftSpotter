using AircraftSpotter.Api.models;
using AircraftSpotter.Domain.Entities;
using AutoMapper;

namespace AircraftSpotter.Api
{
    public class AircraftSightingProfile: Profile
    {
        public AircraftSightingProfile()
        {
            CreateMap<AircraftSighting, AircraftSightingDto>().ReverseMap();
        }
    }
}
