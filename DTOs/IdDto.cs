using API_RandomUser.Models;

namespace API_RandomUser.DTOs
{
    public class IdDto
    {
        public string name { get; set; }
        public string value { get; set; }


        public static implicit operator IdDto(Id id)
        {
            if (id == null) return null;

            return new IdDto
            {
                name = id.name,
                value = id.name
            };
        }

        public IdDto()
        {
        }

        public IdDto(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

    }
}
