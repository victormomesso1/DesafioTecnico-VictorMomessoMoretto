using API_RandomUser.Models;
namespace API_RandomUser.DTOs
{
    public class LocationDto
    {
        public StreetDto street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int postcode { get; set; }
        public CoordinatesDto coordinates { get; set; }
        public TimezoneDto timezone { get; set; }

      
        public static implicit operator LocationDto(Location location)
        {
            if (location == null) return null;

            return new LocationDto
            {
                street = location.street, 
                city = location.city,
                state = location.state,
                country = location.country,
                postcode = location.postcode,
                coordinates = location.coordinates, 
                timezone = location.timezone 
            };
        }

        public LocationDto()
        {
        }

        public LocationDto(StreetDto street, string city, string state, string country, int postcode, CoordinatesDto coordinates, TimezoneDto timezone)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
            this.postcode = postcode;
            this.coordinates = coordinates;
            this.timezone = timezone;
        }
    }
}
