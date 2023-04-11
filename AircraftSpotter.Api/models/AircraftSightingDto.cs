namespace AircraftSpotter.Api.models
{
    public class AircraftSightingDto
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Registration { get; set; }
        public string? Location { get; set; }
        public DateTime DateTimeSeen { get; set; }
    }
}
