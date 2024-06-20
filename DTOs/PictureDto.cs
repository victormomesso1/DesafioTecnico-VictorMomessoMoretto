using API_RandomUser.Models;

namespace API_RandomUser.DTOs
{
    public class PictureDto
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }

        public static implicit operator PictureDto(Picture picture)
        {
            if (picture == null) return null;

            return new PictureDto
            {
                large = picture.large,
                medium = picture.medium,
                thumbnail = picture.thumbnail
            };
        }

        public PictureDto()
        {
        }

        public PictureDto(string large, string medium, string thumbnail)
        {
            this.large = large;
            this.medium = medium;
            this.thumbnail = thumbnail;
        }
    }
}
