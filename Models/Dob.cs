using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class Dob
    {
        public DateTime date { get; set; }
        public int age { get; set; }

        public static implicit operator Dob(DobDto dob)
        {
            if (dob == null) return null;

            return new Dob
            {
                date = dob.date,
                age = dob.age
            };
        }
    }

}
