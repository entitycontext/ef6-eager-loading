using System.Data.Entity;

namespace MovieSite.Database
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(
            DatabaseContext context)
        {
            var data = new SampleData();

            foreach (var artist in data.Artists.Values)
            {
                context.Artists.Add(artist);
            }

            foreach (var character in data.Characters.Values)
            {
                context.Characters.Add(character);
            }

            foreach (var genre in data.Genres.Values)
            {
                context.Genres.Add(genre);
            }

            foreach (var role in data.Roles.Values)
            {
                context.Roles.Add(role);
            }

            foreach (var title in data.Titles.Values)
            {
                context.Titles.Add(title);
            }

            context.SaveChanges();
        }
    }
}