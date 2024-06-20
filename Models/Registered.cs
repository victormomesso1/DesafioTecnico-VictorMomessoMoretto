using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class Registered
    {
        public DateTime date { get; set; }
        public int age { get; set; }

        public static implicit operator Registered(RegisteredDto registered)
        {
            if (registered == null) return null;

            return new Registered
            {
                date = registered.date,
                age = registered.age
            };
        }
    }
}
