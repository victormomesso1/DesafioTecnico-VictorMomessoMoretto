using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class Location
    {
        public Street street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int postcode { get; set; }
        public Coordinates coordinates { get; set; }
        public Timezone timezone { get; set; }


        public static implicit operator Location(LocationDto location)
        {
            if (location == null) return null;

            return new Location
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
    }
}
