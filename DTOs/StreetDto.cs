using API_RandomUser.Models;

namespace API_RandomUser.DTOs
{
    public class StreetDto
    {
        public int number { get; set; }
        public string name { get; set; }

        public static implicit operator StreetDto(Street street)
        {
            if (street == null) return null;

            return new StreetDto
            {
                name = street.name,
                number = street.number
            };
        }

        public StreetDto()
        {
        }

        public StreetDto(int number, string name)
        {
            this.number = number;
            this.name = name;
        }
    }
}
