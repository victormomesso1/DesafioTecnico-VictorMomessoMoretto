using API_RandomUser.DTOs;

namespace API_RandomUser.Models
{
    public class Picture
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }

        public static implicit operator Picture(PictureDto picture)
        {
            if (picture == null) return null;

            return new Picture
            {
                large = picture.large,
                medium = picture.medium,
                thumbnail = picture.thumbnail
            };
        }
    }
}
