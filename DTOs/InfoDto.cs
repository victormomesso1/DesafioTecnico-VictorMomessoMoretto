using API_RandomUser.Models;

namespace API_RandomUser.DTOs
{
    public class InfoDto
    {
        public string seed { get; set; }
        public int results { get; set; }
        public int page { get; set; }
        public string version { get; set; }

        public static implicit operator InfoDto(Info info)
        {
            if (info == null) return null;

            return new InfoDto
            {
                seed = info.seed,
                results = info.results,
                page = info.page,
                version=info.version
            };
        }

        public InfoDto()
        {
        }

        public InfoDto(string seed, int results, int page, string version)
        {
            this.seed = seed;
            this.results = results;
            this.page = page;
            this.version = version;
        }
    }
}
