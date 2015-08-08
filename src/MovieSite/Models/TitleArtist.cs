using System.Collections.Generic;

namespace MovieSite.Models
{
    public class TitleArtist : Entity
    {
        public long TitleId { get; set; }
        public long RoleId { get; set; }
        public long ArtistId { get; set; }

        public virtual Title Title { get; set; }
        public virtual Role Role { get; set; }
        public virtual Artist Artist { get; set; }

        public virtual ICollection<TitleArtistCharacter> TitleArtistCharacters { get; set; } = new List<TitleArtistCharacter>();
    }
}