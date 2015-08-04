using System;
using System.Collections.Generic;

using MovieSite.Models;

namespace MovieSite.Database
{
    public interface IRepository : IDisposable
    {
        Artist GetArtist(long artistId);
        IEnumerable<Artist> GetArtists(IEnumerable<long> artistIds = null);
        Character GetCharacter(long characterId);
        IEnumerable<Character> GetCharacters(IEnumerable<long> characterIds = null);
        Title GetTitle(long titleId);
        IEnumerable<Title> GetTitles(IEnumerable<long> titleIds = null);
    }
}