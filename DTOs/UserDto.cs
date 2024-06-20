using API_RandomUser.Models;

namespace API_RandomUser.DTOs
{
    public class UserDto
    {
        public string gender { get; set; }
        public NameDto name { get; set; }
        public LocationDto location { get; set; }
        public string email { get; set; }
        public LoginDto login { get; set; }
        public DobDto dob { get; set; }
        public RegisteredDto registered { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public IdDto id { get; set; }
        public PictureDto picture { get; set; }
        public string nat { get; set; }

        public int nameId { get; set; }
        public int locationId { get; set; }
        public int loginId { get; set; }
        public int dobId { get; set; }
        public int registeredId { get; set; }
        public int idId { get; set; }
        public int pictureId { get; set; }
        public int user_id { get; set; }

        public static implicit operator UserDto(Result result)
        {
            if (result == null) return null;

            return new UserDto
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
                picture = result.picture
            };
        }
    }
}
    

