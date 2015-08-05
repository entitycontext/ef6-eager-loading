using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using MovieSite.Models;

namespace MovieSite.Database
{
    public abstract class RepositoryBase : IRepository
    {
        protected DatabaseContext _db;

        public RepositoryBase(
            DatabaseContext db)
        {
            _db = db;
#if DEBUG
            _db.Database.Log = o => System.Diagnostics.Debug.Write(o);
            if (_db.Database.Connection is SqlConnection)
            {
                (_db.Database.Connection as SqlConnection).StatisticsEnabled = true;
            }
#endif
        }

        protected void Dispose(
            bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
#if DEBUG
                    if (_db.Database.Connection is SqlConnection)
                    {
                        var stats = (_db.Database.Connection as SqlConnection).RetrieveStatistics();
                        foreach (var key in stats.Keys)
                        {
                            System.Diagnostics.Debug.WriteLine($"{key}\t{stats[key]}");
                        }
                    }
#endif
                    _db.Dispose();
                    _db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Artist GetArtist(
            long artistId)
        {
            return GetArtists(new[] { artistId })
                ?.FirstOrDefault();
        }

        public Character GetCharacter(
            long characterId)
        {
            return GetCharacters(new[] { characterId })
                ?.FirstOrDefault();
        }

        public Title GetTitle(
            long titleId)
        {
            return GetTitles(new[] { titleId })
                ?.FirstOrDefault();
        }

        public abstract IEnumerable<Artist> GetArtists(
            IEnumerable<long> artistIds = null);

        public abstract IEnumerable<Character> GetCharacters(
            IEnumerable<long> characterIds = null);

        public abstract IEnumerable<Title> GetTitles(
            IEnumerable<long> titleIds = null);
    }
}