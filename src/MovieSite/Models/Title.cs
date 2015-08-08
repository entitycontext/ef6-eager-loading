using System.Collections.Generic;

namespace MovieSite.Models
{
    public class Title : Entity
    {
        public string Name { get; set; }
        public string SortName { get; set; }
        public int Year { get; set; }
        public int RuntimeMinutes { get; set; }
        public decimal BudgetMillions { get; set; }
        public decimal GrossMillions { get; set; }

        public virtual ICollection<TitleGenre> TitleGenres { get; set; } = new List<TitleGenre>();
        public virtual ICollection<TitleArtist> TitleArtists { get; set; } = new List<TitleArtist>();
    }
}