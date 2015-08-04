using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using MovieSite.Models;

namespace MovieSite.Database
{
    public class RepositoryExplicitInclude : IRepository
    {
        DatabaseContext _db;

        public RepositoryExplicitInclude(
            DatabaseContext db)
        {
            _db = db;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
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

        public IEnumerable<Artist> GetArtists(
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
             */

            var artistsQuery = _db.Artists.AsQueryable();
            if (artistIds?.Any() == true)
            {
                artistsQuery = artistsQuery.Where(o => artistIds.Contains(o.Id));
            }

            var artists = artistsQuery
                .Include(o => o.TitleArtists.Select(p => p.Title))
                .Include(o => o.TitleArtists.Select(p => p.Role))
                .Include(o => o.TitleArtists.Select(p => p.TitleArtistCharacters.Select(q => q.Character)))
                .OrderBy(o => o.Name)
                .ToList();

            return artists;
        }

        public Character GetCharacter(
            long characterId)
        {
            return GetCharacters(new[] { characterId })
                ?.FirstOrDefault();
        }

        public IEnumerable<Character> GetCharacters(
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
             */

            var charactersQuery = _db.Characters.AsQueryable();
            if (characterIds?.Any() == true)
            {
                charactersQuery = charactersQuery.Where(o => characterIds.Contains(o.Id));
            }

            var characters = charactersQuery
                .Include(o => o.TitleArtistCharacters.Select(p => p.TitleArtist.Title))
                .Include(o => o.TitleArtistCharacters.Select(p => p.TitleArtist.Artist))
                .Include(o => o.TitleArtistCharacters.Select(p => p.TitleArtist.Role))
                .OrderBy(o => o.Name)
                .ToList();

            return characters;
        }

        public Title GetTitle(
            long titleId)
        {
            return GetTitles(new[] { titleId })
                ?.FirstOrDefault();
        }

        public IEnumerable<Title> GetTitles(
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
             */

            var titlesQuery = _db.Titles.AsQueryable();
            if (titleIds?.Any() == true)
            {
                titlesQuery = titlesQuery.Where(o => titleIds.Contains(o.Id));
            }

            var titles = titlesQuery
                .Include(o => o.TitleArtists.Select(p => p.Artist))
                .Include(o => o.TitleArtists.Select(p => p.Role))
                .Include(o => o.TitleArtists.Select(p => p.TitleArtistCharacters.Select(q => q.Character)))
                .Include(o => o.TitleGenres.Select(p => p.Genre))
                .OrderBy(o => o.Name)
                .ToList();

            return titles;
        }
    }
}