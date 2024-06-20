using API_RandomUser.Models;

namespace API_RandomUser.DTOs
{
    public class RegisteredDto
    {
        public DateTime date { get; set; }
        public int age { get; set; }

        public static implicit operator RegisteredDto(Registered registered)
        {
            if (registered == null) return null;

            return new RegisteredDto
            {
                date = registered.date,
                age = registered.age
            };
        }

        public RegisteredDto()
        {
        }

        public RegisteredDto(DateTime date, int age)
        {
            this.date = date;
            this.age = age;
        }
    }
}