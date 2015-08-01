using System.Collections.Generic;

namespace MovieSite.Models
{
    public class TitleArtist : Entity
    {
        public long TitleId { get; set; }
        public long RoleId { get; set; }
        public long? ArtistId { get; set; }
        public long? CharacterId { get; set; }

        public Title Title { get; set; }
        public Role Role { get; set; }
        public Artist Artist { get; set; }

        public ICollection<TitleArtistCharacter> TitleArtistCharacters { get; set; } = new List<TitleArtistCharacter>();
    }
}