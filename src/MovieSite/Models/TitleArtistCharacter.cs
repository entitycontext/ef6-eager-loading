namespace MovieSite.Models
{
    public class TitleArtistCharacter : Entity
    {
        public long TitleArtistId { get; set; }
        public long CharacterId { get; set; }

        public TitleArtist TitleArtist { get; set; }
        public Character Character { get; set; }
    }
}