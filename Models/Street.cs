using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class Street
    {
        public int number { get; set; }
        public string name { get; set; }

        public static implicit operator Street(StreetDto street)
        {
            if (street == null) return null;

            return new Street
            {
                name = street.name,
                number = street.number
            };
        }
    }
}
