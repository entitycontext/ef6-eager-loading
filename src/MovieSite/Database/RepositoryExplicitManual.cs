using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using MovieSite.Models;

namespace MovieSite.Database
{
    public class RepositoryExplicitManual : RepositoryBase
    {
        public RepositoryExplicitManual(
            DatabaseContext db) 
            : base(db)
        {
        }

        public override IEnumerable<Artist> GetArtists(
            IEnumerable<long> artistIds = null)
        {
            /*
             *  Starting from artist, load the relationship tree:
             *
             *  (*)Artist
             *      (*)TitleArtist
             *          (1)Title
             *          (1)Role
             *          (*)TitleArtistCharacter
             *              (1)Character
             *
             *  NOTE: There are 6 database roundtrips.
             */

            var artistsQuery = _db.Artists.AsQueryable();
            if (artistIds?.Any() == true)
            {
                artistsQuery = artistsQuery.Where(o => artistIds.Contains(o.Id));
            }

            var artists = artistsQuery
                .OrderBy(o => o.Name)
                .ToList();

            artistIds = artists
                .Select(o => o.Id);

            if (artistIds.Any())
            {
                var titleArtists = _db.TitleArtists
                    .Where(o => artistIds.Contains(o.ArtistId))
                    .ToList();

                var titleIds = titleArtists
                    .Select(o => o.TitleId)
                    .Distinct();

                if (titleIds.Any())
                {
                    _db.Titles
                        .Where(o => titleIds.Contains(o.Id))
                        .Load();
                }

                var roleIds = titleArtists
                    .Select(o => o.RoleId)
                    .Distinct();

                if (roleIds.Any())
                {
                    _db.Roles
                        .Where(o => roleIds.Contains(o.Id))
                        .Load();
                }

                var titleArtistIds = titleArtists
                    .Select(o => o.Id)
                    .Distinct();

                if (titleArtistIds.Any())
                {
                    var titleArtistCharacters = _db.TitleArtistCharacters
                        .Where(o => titleArtistIds.Contains(o.TitleArtistId))
                        .ToList();

                    var characterIds = titleArtistCharacters
                        .Select(o => o.CharacterId)
                        .Distinct();

                    if (characterIds.Any())
                    {
                        _db.Characters
                            .Where(o => characterIds.Contains(o.Id))
                            .Load();
                    }
                }
            }

            return artists;
        }

        public override IEnumerable<Character> GetCharacters(
            IEnumerable<long> characterIds = null)
        {
            /*
             *  Starting from character, load the relationship tree:
             *
             *  (*)Character
             *      (*)TitleArtistCharacter
             *          (1)TitleArtist
             *              (1)Title
             *              (1)Artist
             *              (1)Role
             *
             *  NOTE: There are 6 database roundtrips.
             */

            var charactersQuery = _db.Characters.AsQueryable();
            if (characterIds?.Any() == true)
            {
                charactersQuery = charactersQuery.Where(o => characterIds.Contains(o.Id));
            }

            var characters = charactersQuery
                .OrderBy(o => o.Name)
                .ToList();

            characterIds = characters
                .Select(o => o.Id);

            if (characterIds.Any())
            {
                var titleArtistCharacters = _db.TitleArtistCharacters
                    .Where(o => characterIds.Contains(o.CharacterId))
                    .ToList();

                var titleArtistIds = titleArtistCharacters
                    .Select(o => o.TitleArtistId)
                    .Distinct();

                if (titleArtistIds.Any())
                {
                    var titleArtists = _db.TitleArtists
                        .Where(o => titleArtistIds.Contains(o.Id))
                        .ToList();

                    var titleIds = titleArtists
                        .Select(o => o.TitleId)
                        .Distinct();

                    if (titleIds.Any())
                    {
                        _db.Titles
                            .Where(o => titleIds.Contains(o.Id))
                            .Load();
                    }

                    var artistIds = titleArtists
                        .Select(o => o.ArtistId)
                        .Distinct();

                    if (artistIds.Any())
                    {
                        _db.Artists
                            .Where(o => artistIds.Contains(o.Id))
                            .Load();
                    }

                    var roleIds = titleArtists
                        .Select(o => o.RoleId)
                        .Distinct();

                    if (roleIds.Any())
                    {
                        _db.Roles
                            .Where(o => roleIds.Contains(o.Id))
                            .Load();
                    }
                }
            }

            return characters;
        }

        public override IEnumerable<Title> GetTitles(
            IEnumerable<long> titleIds = null)
        {
            /*
             *  Starting from title, load the relationship tree:
             *
             *  (*)Title
             *      (*)TitleArtist
             *          (1)Artist
             *          (1)Role
             *          (*)TitleArtistCharacter
             *              (1)Character
             *      (*)TitleGenre
             *          (1) Genre
             *
             *  NOTE: There are 8 database roundtrips.
             */

            var titlesQuery = _db.Titles.AsQueryable();
            if (titleIds?.Any() == true)
            {
                titlesQuery = titlesQuery.Where(o => titleIds.Contains(o.Id));
            }

            var titles = titlesQuery
                .OrderBy(o => o.Id)
                .ToList();

            titleIds = titles
                .Select(o => o.Id);

            if (titleIds.Any())
            {
                var titleArtists = _db.TitleArtists
                    .Where(o => titleIds.Contains(o.TitleId))
                    .ToList();

                var artistIds = titleArtists
                    .Select(o => o.ArtistId)
                    .Distinct();

                if (artistIds.Any())
                {
                    _db.Artists
                        .Where(o => artistIds.Contains(o.Id))
                        .Load();
                }

                var roleIds = titleArtists
                    .Select(o => o.RoleId)
                    .Distinct();

                if (roleIds.Any())
                {
                    _db.Roles
                        .Where(o => roleIds.Contains(o.Id))
                        .Load();
                }

                var titleArtistIds = titleArtists
                    .Select(o => o.Id)
                    .Distinct();

                if (titleArtistIds.Any())
                {
                    var titleArtistCharacters = _db.TitleArtistCharacters
                        .Where(o => titleArtistIds.Contains(o.TitleArtistId))
                        .ToList();

                    var characterIds = titleArtistCharacters
                        .Select(o => o.CharacterId)
                        .Distinct();

                    if (characterIds.Any())
                    {
                        _db.Characters
                            .Where(o => characterIds.Contains(o.Id))
                            .Load();
                    }
                }

                var titleGenres = _db.TitleGenres
                    .Where(o => titleIds.Contains(o.TitleId))
                    .ToList();

                var genreIds = titleGenres
                    .Select(o => o.GenreId)
                    .Distinct();

                if (genreIds.Any())
                {
                    _db.Genres
                        .Where(o => genreIds.Contains(o.Id))
                        .Load();
                }
            }

            return titles;
        }
    }
}