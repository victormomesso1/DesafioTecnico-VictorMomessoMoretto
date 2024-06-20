using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class Id
    {
        public string name { get; set; }
        public string value { get; set; }

        public static implicit operator Id(IdDto id)
        {
            if (id == null) return null;

            return new Id
            {
                name = id.name,
                value = id.name
            };
        }
    }
}
