using System.Collections.Generic;
using System.Linq;

using MovieSite.Models;

namespace MovieSite.Database
{
    public class RepositoryStoredProcedures : RepositoryBase
    {
        public RepositoryStoredProcedures(
            DatabaseContext db) 
            : base(db)
        {
        }

        public override IEnumerable<Artist> GetArtists(
            IEnumerable<long> artistIds = null)
        {
            if (artistIds == null)
            {
                artistIds = _db.Artists
                    .OrderBy(o => o.Name)
                    .Select(o => o.Id)
                    .ToList();
            }

            return StoredProcedures.LoadArtists(_db, artistIds);
        }

        public override IEnumerable<Character> GetCharacters(
            IEnumerable<long> characterIds = null)
        {
            if (characterIds == null)
            {
                characterIds = _db.Characters
                    .OrderBy(o => o.Name)
                    .Select(o => o.Id)
                    .ToList();
            }

            return StoredProcedures.LoadCharacters(_db, characterIds);
        }

        public override IEnumerable<Title> GetTitles(
            IEnumerable<long> titleIds = null)
        {
            if (titleIds == null)
            {
                titleIds = _db.Titles
                    .OrderBy(o => o.Id)
                    .Select(o => o.Id)
                    .ToList();
            }

            return StoredProcedures.LoadTitles(_db, titleIds);
        }
    }
}