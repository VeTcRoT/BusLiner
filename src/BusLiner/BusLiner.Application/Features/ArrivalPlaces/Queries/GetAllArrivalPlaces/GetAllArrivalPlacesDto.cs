namespace BusLiner.Application.Features.ArrivalPlaces.Queries.GetAllArrivalPlaces
{
    public class GetAllArrivalPlacesDto
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
    }
}
