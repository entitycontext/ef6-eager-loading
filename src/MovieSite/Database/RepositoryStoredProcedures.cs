using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public override IEnumerable<Character> GetCharacters(
            IEnumerable<long> characterIds = null)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Title> GetTitles(
            IEnumerable<long> titleIds = null)
        {
            throw new NotImplementedException();
        }
    }
}