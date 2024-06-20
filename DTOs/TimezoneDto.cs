using API_RandomUser.Models;
namespace API_RandomUser.DTOs
{
    public class TimezoneDto
    {
        public string offset { get; set; }
        public string description { get; set; }

        public static implicit operator TimezoneDto(Timezone timezone)
        {
            if (timezone == null) return null;

            return new TimezoneDto
            {
                offset = timezone.offset,
                description = timezone.description
            };
        }

        public TimezoneDto()
        {
        }

        public TimezoneDto(string offset, string description)
        {
            this.offset = offset;
            this.description = description;
        }
    }
}
