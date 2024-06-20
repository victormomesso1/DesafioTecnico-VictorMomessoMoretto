using API_RandomUser.Models;

namespace API_RandomUser.DTOs
{
    public class CoordinatesDto
    {
        public string? latitude { get; set; }
        public string? longitude { get; set; }

        public static implicit operator CoordinatesDto(Coordinates coordinates)
        {
            if (coordinates == null) return null;

            return new CoordinatesDto
            {
                latitude = coordinates.latitude,
                longitude = coordinates.longitude
            };
        }

        public CoordinatesDto()
        {
        }

        public CoordinatesDto(string? latitude, string? longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

    }
}
