using System.Data.Entity;

namespace MovieSite.Database
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(
            DatabaseContext db)
        {
            DatabaseStoredProcedures.Generate(db);

            var data = new SampleData();

            foreach (var artist in data.Artists.Values)
            {
                db.Artists.Add(artist);
            }

            foreach (var character in data.Characters.Values)
            {
                db.Characters.Add(character);
            }

            foreach (var genre in data.Genres.Values)
            {
                db.Genres.Add(genre);
            }

            foreach (var role in data.Roles.Values)
            {
                db.Roles.Add(role);
            }

            foreach (var title in data.Titles.Values)
            {
                db.Titles.Add(title);
            }

            db.SaveChanges();
        }
    }
}