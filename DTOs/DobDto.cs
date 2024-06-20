using API_RandomUser.Models;

namespace API_RandomUser.DTOs
{
    public class DobDto
    {
        public DateTime date { get; set; }
        public int age { get; set; }

        public static implicit operator DobDto(Dob dob)
        {
            if (dob == null) return null;

            return new DobDto
            {
                date = dob.date,
                age = dob.age
            };
        }

        public DobDto()
        {
        }

        public DobDto(DateTime date, int age)
        {
            this.date = date;
            this.age = age;
        }
    }
}
