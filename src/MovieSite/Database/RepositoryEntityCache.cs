using System.Collections.Generic;
using System.Linq;

using MovieSite.Models;

namespace MovieSite.Database
{
    public class RepositoryEntityCache : RepositoryBase
    {
        public RepositoryEntityCache(
            DatabaseContext db) 
            : base(db)
        {
            EntityCache.Attach(db);
        }

        public override IEnumerable<Artist> GetArtists(
            IEnumerable<long> artistIds = null)
        {
            var artistsQuery = _db.Artists.Local.AsQueryable();
            if (artistIds?.Any() == true)
            {
                artistsQuery = artistsQuery.Where(o => artistIds.Contains(o.Id));
            }

            return artistsQuery
                .OrderBy(o => o.Name);
        }

        public override IEnumerable<Character> GetCharacters(
            IEnumerable<long> characterIds = null)
        {
            var charactersQuery = _db.Characters.Local.AsQueryable();
            if (characterIds?.Any() == true)
            {
                charactersQuery = charactersQuery.Where(o => characterIds.Contains(o.Id));
            }

            return charactersQuery
                .OrderBy(o => o.Name);
        }

        public override IEnumerable<Title> GetTitles(
            IEnumerable<long> titleIds = null)
        {
            var titlesQuery = _db.Titles.Local.AsQueryable();
            if (titleIds?.Any() == true)
            {
                titlesQuery = titlesQuery.Where(o => titleIds.Contains(o.Id));
            }

            return titlesQuery
                .OrderBy(o => o.Id);
        }
    }
}