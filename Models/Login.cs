using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class Login
    {
        public string uuid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }

        public static implicit operator Login(LoginDto login)
        {
            if (login == null) return null;

            return new Login
            {
                uuid = login.uuid,
                username = login.username,
                salt = login.salt
            };
        }
    }
}
