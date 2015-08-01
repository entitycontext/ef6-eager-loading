using System.Collections.Generic;

namespace MovieSite.Models
{
    public class Character : Entity
    {
        public string Name { get; set; }

        public ICollection<TitleArtistCharacter> TitleArtistCharacters { get; set; } = new List<TitleArtistCharacter>();
    }
}