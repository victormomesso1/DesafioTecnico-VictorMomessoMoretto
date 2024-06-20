using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }

        public static implicit operator Name(NameDto name)
        {
            if (name == null) return null;

            return new Name
            {
                title = name.title,
                first = name.first,
                last = name.last
            };
        }
    }
}

