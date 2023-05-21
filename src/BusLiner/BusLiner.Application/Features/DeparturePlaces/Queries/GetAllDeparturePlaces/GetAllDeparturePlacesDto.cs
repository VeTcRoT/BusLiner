namespace BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces
{
    public class GetAllDeparturePlacesDto
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
    }
}
