using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class Timezone
    {
        public string offset { get; set; }
        public string description { get; set; }

        public static implicit operator Timezone(TimezoneDto timezone)
        {
            if (timezone == null) return null;

            return new Timezone
            {
                offset = timezone.offset,
                description = timezone.description
            };
        }
    }
}
