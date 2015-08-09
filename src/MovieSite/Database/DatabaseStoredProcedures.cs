namespace MovieSite.Database
{
    public static class DatabaseStoredProcedures
    {
        private static string DeclareArtistTableVar =
            @"DECLARE @Artist TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [Name] NVARCHAR(255) NOT NULL
            )";

        private static string ArtistCols =
            "[Artist].[Id], [Artist].[Name]";

        private static string DeclareCharacterTableVar =
            @"DECLARE @Character TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [Name] NVARCHAR(255) NOT NULL
            )";

        private static string CharacterCols =
            "[Character].[Id], [Character].[Name]";

        private static string DeclareGenreTableVar =
            @"DECLARE @Genre TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [Name] NVARCHAR(255) NOT NULL
            )";

        private static string GenreCols =
            "[Genre].[Id], [Genre].[Name]";

        private static string DeclareRoleTableVar =
            @"DECLARE @Role TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [Name] NVARCHAR(255) NOT NULL
            )";

        private static string RoleCols =
            "[Role].[Id], [Role].[Name]";

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

        private static string DeclareTitleArtistCharacterTableVar =
            @"DECLARE @TitleArtistCharacter TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [TitleArtistId] BIGINT NOT NULL,
	            [CharacterId] BIGINT NOT NULL
            )";

        private static string TitleArtistCharacterCols =
            "[TitleArtistCharacter].[Id], [TitleArtistCharacter].[TitleArtistId], [TitleArtistCharacter].[CharacterId]";

        private static string DeclareTitleGenreTableVar =
            @"DECLARE @TitleGenre TABLE 
            (
	            [Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON), 
	            [TitleId] BIGINT NOT NULL,
	            [GenreId] BIGINT NOT NULL
            )";

        private static string TitleGenreCols =
            "[TitleGenre].[Id], [TitleGenre].[TitleId], [TitleGenre].[GenreId]";

        private static string CreateIdTableType =
            "CREATE TYPE [dbo].[IdTableType] AS TABLE([Id] BIGINT NOT NULL)";

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

        private static string CreateLoadArtistsProc =
            $@"CREATE PROCEDURE [dbo].[LoadArtists] (@Ids IdTableType READONLY) AS BEGIN

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
            SELECT {GenreCols} FROM @Genre AS [Genre]
            SELECT {RoleCols} FROM @Role AS [Role]
            SELECT {TitleCols} FROM @Title AS [Title]
            SELECT {TitleArtistCols} FROM @TitleArtist AS [TitleArtist]
            SELECT {TitleArtistCharacterCols} FROM @TitleArtistCharacter AS [TitleArtistCharacter]
            SELECT {TitleGenreCols} FROM @TitleGenre AS [TitleGenre]

            END";

        private static string CreateLoadCharactersProc =
            $@"CREATE PROCEDURE [dbo].[LoadCharacters] (@Ids IdTableType READONLY) AS BEGIN

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
            SELECT {GenreCols} FROM @Genre AS [Genre]
            SELECT {RoleCols} FROM @Role AS [Role]
            SELECT {TitleCols} FROM @Title AS [Title]
            SELECT {TitleArtistCols} FROM @TitleArtist AS [TitleArtist]
            SELECT {TitleArtistCharacterCols} FROM @TitleArtistCharacter AS [TitleArtistCharacter]
            SELECT {TitleGenreCols} FROM @TitleGenre AS [TitleGenre]

            END";

        public static void Generate(
            DatabaseContext db)
        {
            db.Database.ExecuteSqlCommand(CreateIdTableType);
            db.Database.ExecuteSqlCommand(CreateLoadTitlesProc);
            db.Database.ExecuteSqlCommand(CreateLoadArtistsProc);
            db.Database.ExecuteSqlCommand(CreateLoadCharactersProc);
        }
    }
}