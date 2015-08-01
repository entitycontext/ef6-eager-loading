using System.Collections.Generic;

namespace MovieSite.Models
{
    public class Genre : Entity
    {
        public string Name { get; set; }

        public ICollection<TitleGenre> TitleGenres { get; set; } = new List<TitleGenre>();
    }
}