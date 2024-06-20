using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class Coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }

        public static implicit operator Coordinates(CoordinatesDto coordinates)
        {
            if (coordinates == null) return null;

            return new Coordinates
            {
                latitude = coordinates.latitude,
                longitude = coordinates.longitude
            };
        }
    }
}
