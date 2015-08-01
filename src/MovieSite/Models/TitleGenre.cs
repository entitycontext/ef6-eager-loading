namespace MovieSite.Models
{
    public class TitleGenre : Entity
    {
        public long TitleId { get; set; }
        public long GenreId { get; set; }

        public Title Title { get; set; }
        public Genre Genre { get; set; }
    }
}