namespace MovieSite.Models
{
    public class TitleArtistCharacter : Entity
    {
        public long TitleArtistId { get; set; }
        public long CharacterId { get; set; }

        public virtual TitleArtist TitleArtist { get; set; }
        public virtual Character Character { get; set; }
    }
}