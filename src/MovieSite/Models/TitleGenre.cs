namespace MovieSite.Models
{
    public class TitleGenre : Entity
    {
        public long TitleId { get; set; }
        public long GenreId { get; set; }

        public virtual Title Title { get; set; }
        public virtual Genre Genre { get; set; }
    }
}