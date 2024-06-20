using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class UserResult
    {
        public List<Result> results { get; set; }
        public Info info { get; set; }
    }

    public class Result
    {
        public string gender { get; set; }
        public Name name { get; set; }
        public Location location { get; set; }
        public string email { get; set; }
        public Login login { get; set; }
        public Dob dob { get; set; }
        public Registered registered { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public Id id { get; set; }
        public Picture picture { get; set; }
        public string nat { get; set; }

        public static implicit operator Result(UserDto result)
        {
            if (result == null) return null;

            return new Result
            {
                gender = result.gender,
                nameId = result.nameId,
                locationId = result.locationId,
                email = result.email,
                loginId = result.loginId,
                dobId = result.dobId,
                registeredId = result.registeredId,
                phone = result.phone,
                cell = result.cell,
                idId = result.idId,
                pictureId = result.pictureId,
                nat = result.nat,
                user_id = result.user_id,
                name = result.name,
                login = result.login,
                location = result.location,
                dob = result.dob,
                registered = result.registered,
                id = result.id,
                picture = result.picture,
                
            };
        }


        public int nameId { get; set; }
        public int locationId { get; set; }
        public int loginId { get; set; }
        public int dobId { get; set; }
        public int registeredId { get; set; }
        public int idId { get; set; }
        public int pictureId { get; set; }
        public int user_id {  get; set; }
    }
}