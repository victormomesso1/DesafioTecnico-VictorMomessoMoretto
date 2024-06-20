using API_RandomUser.Models;

namespace API_RandomUser.DTOs
{
    public class NameDto
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }

        public static implicit operator NameDto(Name name)
        {
            if (name == null) return null;

            return new NameDto
            {
                title = name.title,
                first = name.first,
                last = name.last
            };
        }

        public NameDto()
        {
        }

        public NameDto(string title, string first, string last)
        {
            this.title = title;
            this.first = first;
            this.last = last;
        }
    }
}
