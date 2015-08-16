using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using MovieSite.Models;

namespace MovieSite.Database
{
    public static class EntityCache
    {
        private class CachedEntities
        {
            public ICollection<Artist> Artists { get; set; } = new List<Artist>();
            public ICollection<Character> Characters { get; set; } = new List<Character>();
            public ICollection<Genre> Genres { get; set; } = new List<Genre>();
            public ICollection<Role> Roles { get; set; } = new List<Role>();
            public ICollection<Title> Titles { get; set; } = new List<Title>();
            public ICollection<TitleArtist> TitleArtists { get; set; } = new List<TitleArtist>();
            public ICollection<TitleArtistCharacter> TitleArtistCharacters { get; set; } = new List<TitleArtistCharacter>();
            public ICollection<TitleGenre> TitleGenres { get; set; } = new List<TitleGenre>();
        }

        private class CachedEntitiesContractResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(
                Type type, 
                MemberSerialization memberSerialization)
            {
                var properties = base.CreateProperties(type, memberSerialization);

                if (type.IsSubclassOf(typeof(Entity)))
                {
                    properties = properties
                        .Where(o => !o.PropertyType.IsSubclassOf(typeof(Entity)) &&
                                    !(o.PropertyType.IsGenericType && 
                                      o.PropertyType.GenericTypeArguments.Any(p => p.IsSubclassOf(typeof(Entity)))))
                        .ToList();
                }

                return properties;
            }
        }

        public static void Refresh()
        {
            using (var db = new DatabaseContext())
            {
                db.Artists.Load();
                db.Characters.Load();
                db.Genres.Load();
                db.Roles.Load();
                db.Titles.Load();
                db.TitleArtists.Load();
                db.TitleArtistCharacters.Load();
                db.TitleGenres.Load();

                var entities = new CachedEntities
                {
                    Artists = db.Artists.Local,
                    Characters = db.Characters.Local,
                    Genres = db.Genres.Local,
                    Roles = db.Roles.Local,
                    Titles = db.Titles.Local,
                    TitleArtists = db.TitleArtists.Local,
                    TitleArtistCharacters = db.TitleArtistCharacters.Local,
                    TitleGenres = db.TitleGenres.Local
                };

                var json = JsonConvert.SerializeObject(
                    entities, 
                    Formatting.Indented, 
                    settings: new JsonSerializerSettings
                    {
                        ContractResolver = new CachedEntitiesContractResolver()
                    });

                MemoryCache.Default[nameof(EntityCache)] = json;
            }
        }

        public static void Attach(
            DatabaseContext db)
        {
            var json = MemoryCache.Default[nameof(EntityCache)] as string;
            if (!string.IsNullOrWhiteSpace(json))
            {
                var entities = JsonConvert.DeserializeObject<CachedEntities>(json);
                if (entities != null)
                {
                    foreach (var artist in entities.Artists)
                    {
                        db.Artists.Attach(artist);
                    }
                    foreach (var character in entities.Characters)
                    {
                        db.Characters.Attach(character);
                    }
                    foreach (var genre in entities.Genres)
                    {
                        db.Genres.Attach(genre);
                    }
                    foreach (var role in entities.Roles)
                    {
                        db.Roles.Attach(role);
                    }
                    foreach (var title in entities.Titles)
                    {
                        db.Titles.Attach(title);
                    }
                    foreach (var titleArtist in entities.TitleArtists)
                    {
                        db.TitleArtists.Attach(titleArtist);
                    }
                    foreach (var titleArtistCharacter in entities.TitleArtistCharacters)
                    {
                        db.TitleArtistCharacters.Attach(titleArtistCharacter);
                    }
                    foreach (var titleGenre in entities.TitleGenres)
                    {
                        db.TitleGenres.Attach(titleGenre);
                    }
                }
            }
        }
    }
}