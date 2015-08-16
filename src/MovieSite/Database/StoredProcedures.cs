using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

using MovieSite.Models;

namespace MovieSite.Database
{
    using ObjectTranslator = Action<ObjectContext, DbDataReader>;

    public static class StoredProcedures
    {
        private static ObjectTranslator GetTranslator<TEntity>(string setName) =>
            (context, reader) => context.Translate<TEntity>(reader, setName, MergeOption.AppendOnly).ToList();

        private static string CreateIdTableType =
            "CREATE TYPE [dbo].[IdTableType] AS TABLE([Id] BIGINT NOT NULL)";

        //
        // Artist table variable and column list
        //

        private static string DeclareArtistTableVar =
            @"DECLARE @Artist TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [Name] NVARCHAR(255) NOT NULL
            )";

        private static string ArtistCols =
            "[Artist].[Id], [Artist].[Name]";

        //
        // Character table variable and column list
        //

        private static string DeclareCharacterTableVar =
            @"DECLARE @Character TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [Name] NVARCHAR(255) NOT NULL
            )";

        private static string CharacterCols =
            "[Character].[Id], [Character].[Name]";

        //
        // Genre table variable and column list
        //

        private static string DeclareGenreTableVar =
            @"DECLARE @Genre TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [Name] NVARCHAR(255) NOT NULL
            )";

        private static string GenreCols =
            "[Genre].[Id], [Genre].[Name]";

        //
        // Role table variable and column list
        //

        private static string DeclareRoleTableVar =
            @"DECLARE @Role TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [Name] NVARCHAR(255) NOT NULL
            )";

        private static string RoleCols =
            "[Role].[Id], [Role].[Name]";

        //
        // Title table variable and column list
        //

        private static string DeclareTitleTableVar =
            @"DECLARE @Title TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [Name] NVARCHAR(255) NOT NULL,
	            [Year] INT NOT NULL,
	            [RuntimeMinutes] INT NOT NULL,
	            [BudgetMillions] DECIMAL(7,2) NOT NULL,
	            [GrossMillions] DECIMAL(7,2) NOT NULL
            )";

        private static string TitleCols =
            "[Title].[Id], [Title].[Name], [Title].[Year], [Title].[RuntimeMinutes], [Title].[BudgetMillions], [Title].[GrossMillions]";

        //
        // TitleArtist table variable and column list
        //

        private static string DeclareTitleArtistTableVar =
            @"DECLARE @TitleArtist TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [TitleId] BIGINT NOT NULL,
	            [RoleId] BIGINT NOT NULL,
	            [ArtistId] BIGINT NOT NULL
            )";

        private static string TitleArtistCols =
            "[TitleArtist].[Id], [TitleArtist].[TitleId], [TitleArtist].[RoleId], [TitleArtist].[ArtistId]";

        //
        // TitleArtistCharacter table variable and column list
        //

        private static string DeclareTitleArtistCharacterTableVar =
            @"DECLARE @TitleArtistCharacter TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [TitleArtistId] BIGINT NOT NULL,
	            [CharacterId] BIGINT NOT NULL
            )";

        private static string TitleArtistCharacterCols =
            "[TitleArtistCharacter].[Id], [TitleArtistCharacter].[TitleArtistId], [TitleArtistCharacter].[CharacterId]";

        //
        // TitleGenre table variable and column list
        //

        private static string DeclareTitleGenreTableVar =
            @"DECLARE @TitleGenre TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [TitleId] BIGINT NOT NULL,
	            [GenreId] BIGINT NOT NULL
            )";

        private static string TitleGenreCols =
            "[TitleGenre].[Id], [TitleGenre].[TitleId], [TitleGenre].[GenreId]";

        //
        // LoadArtists stored procedure and object translators
        //

        private static string CreateLoadArtistsProc =
            $@"CREATE PROCEDURE [dbo].[LoadArtists] (@Ids IdTableType READONLY) AS BEGIN

            --------------------------
            -- Declare table variables
            --------------------------

            {DeclareArtistTableVar}
            {DeclareCharacterTableVar}
            {DeclareRoleTableVar}
            {DeclareTitleTableVar}
            {DeclareTitleArtistTableVar}
            {DeclareTitleArtistCharacterTableVar}

            ---------------------------
            -- Populate table variables
            ---------------------------

            INSERT INTO @Artist 
                SELECT {ArtistCols}
                FROM [Artist]
                WHERE [Id] IN (SELECT [Id] FROM @Ids)

            INSERT INTO @TitleArtist 
                SELECT {TitleArtistCols}
                FROM [TitleArtist]
                INNER JOIN @Artist AS [Artist] ON [Artist].[Id] = [TitleArtist].[ArtistId]

            INSERT INTO @TitleArtistCharacter 
                SELECT {TitleArtistCharacterCols}
                FROM [TitleArtistCharacter]
                INNER JOIN @TitleArtist AS [TitleArtist] ON [TitleArtist].[Id] = [TitleArtistCharacter].[TitleArtistId]

            INSERT INTO @Title
                SELECT DISTINCT {TitleCols}
                FROM [Title]
                INNER JOIN @TitleArtist AS [TitleArtist] ON [TitleArtist].[TitleId] = [Title].[Id]

            INSERT INTO @Character
                SELECT DISTINCT {CharacterCols}
                FROM [Character]
                INNER JOIN @TitleArtistCharacter AS [TitleArtistCharacter] ON [TitleArtistCharacter].[CharacterId] = [Character].[Id]

            INSERT INTO @Role
                SELECT DISTINCT {RoleCols}
                FROM [Role]
                INNER JOIN @TitleArtist AS [TitleArtist] ON [TitleArtist].[RoleId] = [Role].[Id]

            -------------------------------------
            -- Return contents of table variables
            -------------------------------------

            SELECT {ArtistCols} FROM @Artist AS [Artist]
            SELECT {CharacterCols} FROM @Character AS [Character]
            SELECT {RoleCols} FROM @Role AS [Role]
            SELECT {TitleCols} FROM @Title AS [Title]
            SELECT {TitleArtistCols} FROM @TitleArtist AS [TitleArtist]
            SELECT {TitleArtistCharacterCols} FROM @TitleArtistCharacter AS [TitleArtistCharacter]

            END";

        private static IEnumerable<ObjectTranslator> LoadArtistsTranslators = new ObjectTranslator[]
        {
            GetTranslator<Artist>(nameof(DatabaseContext.Artists)),
            GetTranslator<Character>(nameof(DatabaseContext.Characters)),
            GetTranslator<Role>(nameof(DatabaseContext.Roles)),
            GetTranslator<Title>(nameof(DatabaseContext.Titles)),
            GetTranslator<TitleArtist>(nameof(DatabaseContext.TitleArtists)),
            GetTranslator<TitleArtistCharacter>(nameof(DatabaseContext.TitleArtistCharacters))
        };

        //
        // LoadCharacters stored procedure and object translators
        //

        private static string CreateLoadCharactersProc =
            $@"CREATE PROCEDURE [dbo].[LoadCharacters] (@Ids IdTableType READONLY) AS BEGIN

            --------------------------
            -- Declare table variables
            --------------------------

            {DeclareArtistTableVar}
            {DeclareCharacterTableVar}
            {DeclareRoleTableVar}
            {DeclareTitleTableVar}
            {DeclareTitleArtistTableVar}
            {DeclareTitleArtistCharacterTableVar}

            ---------------------------
            -- Populate table variables
            ---------------------------

            INSERT INTO @Character 
                SELECT {CharacterCols}
                FROM [Character] 
                WHERE [Id] IN (SELECT [Id] FROM @Ids)

            INSERT INTO @TitleArtistCharacter 
                SELECT {TitleArtistCharacterCols}
                FROM [TitleArtistCharacter]
                INNER JOIN @Character AS [Character] ON [Character].[Id] = [TitleArtistCharacter].[CharacterId]

            INSERT INTO @TitleArtist
                SELECT {TitleArtistCols}
                FROM [TitleArtist]
                INNER JOIN @TitleArtistCharacter AS [TitleArtistCharacter] ON [TitleArtistCharacter].[TitleArtistId] = [TitleArtist].[Id]

            INSERT INTO @Title
                SELECT DISTINCT {TitleCols}
                FROM [Title]
                INNER JOIN @TitleArtist AS [TitleArtist] ON [TitleArtist].[TitleId] = [Title].[Id]

            INSERT INTO @Artist
                SELECT DISTINCT {ArtistCols}
                FROM [Artist]
                INNER JOIN @TitleArtist AS [TitleArtist] ON [TitleArtist].[ArtistId] = [Artist].[Id]

            INSERT INTO @Role
                SELECT DISTINCT {RoleCols}
                FROM [Role]
                INNER JOIN @TitleArtist AS [TitleArtist] ON [TitleArtist].[RoleId] = [Role].[Id]

            -------------------------------------
            -- Return contents of table variables
            -------------------------------------

            SELECT {ArtistCols} FROM @Artist AS [Artist]
            SELECT {CharacterCols} FROM @Character AS [Character]
            SELECT {RoleCols} FROM @Role AS [Role]
            SELECT {TitleCols} FROM @Title AS [Title]
            SELECT {TitleArtistCols} FROM @TitleArtist AS [TitleArtist]
            SELECT {TitleArtistCharacterCols} FROM @TitleArtistCharacter AS [TitleArtistCharacter]

            END";

        private static IEnumerable<ObjectTranslator> LoadCharactersTranslators = new ObjectTranslator[]
        {
            GetTranslator<Artist>(nameof(DatabaseContext.Artists)),
            GetTranslator<Character>(nameof(DatabaseContext.Characters)),
            GetTranslator<Role>(nameof(DatabaseContext.Roles)),
            GetTranslator<Title>(nameof(DatabaseContext.Titles)),
            GetTranslator<TitleArtist>(nameof(DatabaseContext.TitleArtists)),
            GetTranslator<TitleArtistCharacter>(nameof(DatabaseContext.TitleArtistCharacters))
        };

        //
        // LoadTitles stored procedure and object translators
        //

        private static string CreateLoadTitlesProc =
            $@"CREATE PROCEDURE [dbo].[LoadTitles] (@Ids IdTableType READONLY) AS BEGIN

            --------------------------
            -- Declare table variables
            --------------------------

            {DeclareArtistTableVar}
            {DeclareCharacterTableVar}
            {DeclareGenreTableVar}
            {DeclareRoleTableVar}
            {DeclareTitleTableVar}
            {DeclareTitleArtistTableVar}
            {DeclareTitleArtistCharacterTableVar}
            {DeclareTitleGenreTableVar}

            ---------------------------
            -- Populate table variables
            ---------------------------

            INSERT INTO @Title 
                SELECT {TitleCols}
                FROM [Title] 
                WHERE [Id] IN (SELECT [Id] FROM @Ids)

            INSERT INTO @TitleArtist 
                SELECT {TitleArtistCols}
                FROM [TitleArtist]
                INNER JOIN @Title AS [Title] ON [Title].[Id] = [TitleArtist].[TitleId]

            INSERT INTO @TitleArtistCharacter 
                SELECT {TitleArtistCharacterCols}
                FROM [TitleArtistCharacter]
                INNER JOIN @TitleArtist AS [TitleArtist] ON [TitleArtist].[Id] = [TitleArtistCharacter].[TitleArtistId]

            INSERT INTO @TitleGenre
                SELECT {TitleGenreCols}
                FROM [TitleGenre]
                INNER JOIN @Title AS [Title] ON [Title].[Id] = [TitleGenre].[TitleId]

            INSERT INTO @Artist
                SELECT DISTINCT {ArtistCols}
                FROM [Artist]
                INNER JOIN @TitleArtist AS [TitleArtist] ON [TitleArtist].[ArtistId] = [Artist].[Id]

            INSERT INTO @Character
                SELECT DISTINCT {CharacterCols}
                FROM [Character]
                INNER JOIN @TitleArtistCharacter AS [TitleArtistCharacter] ON [TitleArtistCharacter].[CharacterId] = [Character].[Id]

            INSERT INTO @Genre
                SELECT DISTINCT {GenreCols}
                FROM [Genre]
                INNER JOIN @TitleGenre AS [TitleGenre] ON [TitleGenre].[GenreId] = [Genre].[Id]

            INSERT INTO @Role
                SELECT DISTINCT {RoleCols}
                FROM [Role]
                INNER JOIN @TitleArtist AS [TitleArtist] ON [TitleArtist].[RoleId] = [Role].[Id]

            -------------------------------------
            -- Return contents of table variables
            -------------------------------------

            SELECT {ArtistCols} FROM @Artist AS [Artist]
            SELECT {CharacterCols} FROM @Character AS [Character]
            SELECT {GenreCols} FROM @Genre AS [Genre]
            SELECT {RoleCols} FROM @Role AS [Role]
            SELECT {TitleCols} FROM @Title AS [Title]
            SELECT {TitleArtistCols} FROM @TitleArtist AS [TitleArtist]
            SELECT {TitleArtistCharacterCols} FROM @TitleArtistCharacter AS [TitleArtistCharacter]
            SELECT {TitleGenreCols} FROM @TitleGenre AS [TitleGenre]

            END";

        private static IEnumerable<ObjectTranslator> LoadTitlesTranslators = new ObjectTranslator[]
        {
            GetTranslator<Artist>(nameof(DatabaseContext.Artists)),
            GetTranslator<Character>(nameof(DatabaseContext.Characters)),
            GetTranslator<Genre>(nameof(DatabaseContext.Genres)),
            GetTranslator<Role>(nameof(DatabaseContext.Roles)),
            GetTranslator<Title>(nameof(DatabaseContext.Titles)),
            GetTranslator<TitleArtist>(nameof(DatabaseContext.TitleArtists)),
            GetTranslator<TitleArtistCharacter>(nameof(DatabaseContext.TitleArtistCharacters)),
            GetTranslator<TitleGenre>(nameof(DatabaseContext.TitleGenres))
        };

        public static void Generate(
            DatabaseContext db)
        {
            db.Database.ExecuteSqlCommand(CreateIdTableType);
            db.Database.ExecuteSqlCommand(CreateLoadArtistsProc);
            db.Database.ExecuteSqlCommand(CreateLoadCharactersProc);
            db.Database.ExecuteSqlCommand(CreateLoadTitlesProc);
        }

        public static IEnumerable<Artist> LoadArtists(
            DatabaseContext db,
            IEnumerable<long> artistIds)
        {
            return LoadEntities<Artist>(
                db, artistIds,
                "LoadArtists",
                LoadArtistsTranslators,
                (id) => db.Artists.Local.FirstOrDefault(o => o.Id == id));
        }

        public static IEnumerable<Character> LoadCharacters(
            DatabaseContext db,
            IEnumerable<long> characterIds)
        {
            return LoadEntities<Character>(
                db, characterIds,
                "LoadCharacters",
                LoadCharactersTranslators,
                (id) => db.Characters.Local.FirstOrDefault(o => o.Id == id));
        }

        public static IEnumerable<Title> LoadTitles(
            DatabaseContext db,
            IEnumerable<long> titleIds)
        {
            return LoadEntities<Title>(
                db, titleIds,
                "LoadTitles",
                LoadTitlesTranslators,
                (id) => db.Titles.Local.FirstOrDefault(o => o.Id == id));
        }

        private static DataTable CreateIdTable(
            IEnumerable<long> ids)
        {
            var idTable = new DataTable();
            idTable.Columns.Add(new DataColumn("Id"));
            foreach (var id in ids)
            {
                idTable.Rows.Add(id);
            }
            return idTable;
        }

        private static IEnumerable<TEntity> LoadEntities<TEntity>(
            DatabaseContext db,
            IEnumerable<long> ids,
            string procedureName,
            IEnumerable<ObjectTranslator> objectTranslators,
            Func<long, TEntity> findLocalEntity)
        {
            var entities = new List<TEntity>();

            if (ids.Any())
            {

                var connection = db.Database.Connection;
                var closeConnection = false;

                try
                {
                    //
                    // Create SQL command for calling stored procedure.
                    //

                    var command = (SqlCommand)connection.CreateCommand();
                    command.CommandText = procedureName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"Ids", CreateIdTable(ids));

                    //
                    // Open DB connection if it's closed.
                    //

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                        closeConnection = true;
                    }

                    //
                    // Execute reader and translate result sets into local DB entities.
                    //

                    using (var reader = command.ExecuteReader())
                    {
                        var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                        foreach (var translateObjects in objectTranslators)
                        {
                            translateObjects(objectContext, reader);

                            if (translateObjects != objectTranslators.Last())
                            {
                                reader.NextResult();
                            }
                        }
                    }
                }
                finally
                {
                    if (closeConnection)
                    {
                        connection.Close();
                    }
                }

                //
                // Iterate through passed id list, find matching local entity and add to result set.
                // This puts the returned entity list in the same order as the passed in id list.
                //

                foreach (var id in ids)
                {
                    var entity = findLocalEntity(id);
                    if (entity != null)
                    {
                        entities.Add(entity);
                    }
                }
            }

            return entities;
        }
    }
}