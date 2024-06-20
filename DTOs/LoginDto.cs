using API_RandomUser.Models;

namespace API_RandomUser.DTOs
{
    public class LoginDto
    {
        public string uuid { get; set; }
        public string username { get; set; }

        //public string Password { get; set; } dado sensivel, não quero incluir no DTO
        public string salt { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string? sha256 { get; set; }

        public static implicit operator LoginDto(Login login)
        {
            if (login == null) return null;

            return new LoginDto
            {   uuid = login.uuid,
                username = login.username,
                salt = login.salt,
                md5 = login.md5,
                sha1 = login.sha1,
                sha256 = login.sha256
            };
        }

        public LoginDto()
        {
        }

        public LoginDto(string uuid, string username, string salt, string md5, string sha1, string? sha256)
        {
            this.uuid = uuid;
            this.username = username;
            this.salt = salt;
            this.md5 = md5;
            this.sha1 = sha1;
            this.sha256 = sha256;
        }

    }
}
