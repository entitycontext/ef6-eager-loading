using System.Collections.Generic;

namespace MovieSite.Models
{
    public class Genre : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<TitleGenre> TitleGenres { get; set; } = new List<TitleGenre>();
    }
}