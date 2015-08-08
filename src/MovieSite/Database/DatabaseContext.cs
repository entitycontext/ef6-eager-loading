using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;

using MovieSite.Models;

namespace MovieSite.Database
{
    public class DatabaseContext : DbContext
    {
        #region Entities

        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Character> Characters { get; set; }
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<Title> Titles { get; set; }
        public IDbSet<TitleArtist> TitleArtists { get; set; }
        public IDbSet<TitleArtistCharacter> TitleArtistCharacters { get; set; }
        public IDbSet<TitleGenre> TitleGenres { get; set; }

        #endregion

        #region Configuration

        static DatabaseContext()
        {
            System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());
        }

        public DatabaseContext()
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(
            DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //
            // Configure Artist
            //

            var artist = modelBuilder.Entity<Artist>()
                .HasKey(o => o.Id);

            artist.Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            artist.Property(o => o.Name)
                .HasMaxLength(255);

            //
            // Configure Character
            //

            var character = modelBuilder.Entity<Character>()
                .HasKey(o => o.Id);

            artist.Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            character.Property(o => o.Name)
                .HasMaxLength(255);


            //
            // Configure Genre
            //

            var genre = modelBuilder.Entity<Genre>()
                .HasKey(o => o.Id);

            artist.Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            genre.Property(o => o.Name)
                .HasMaxLength(255);

            //
            // Configure Role
            //

            var role = modelBuilder.Entity<Role>()
                .HasKey(o => o.Id);

            role.Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            role.Property(o => o.Name)
                .HasMaxLength(255);

            //
            // Configure Title
            //

            var title = modelBuilder.Entity<Title>()
                .HasKey(o => o.Id);

            title.Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            title.Property(o => o.Name)
                .HasMaxLength(255);

            title.Property(o => o.Year);

            title.Property(o => o.RuntimeMinutes);

            title.Property(o => o.BudgetMillions)
                .HasPrecision(7, 2);

            title.Property(o => o.GrossMillions)
                .HasPrecision(7, 2);

            //
            // Configure TitleArtist
            //

            var titleArtist = modelBuilder.Entity<TitleArtist>()
                .HasKey(o => o.Id);

            titleArtist.Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            titleArtist.HasRequired(o => o.Title)
                .WithMany(o => o.TitleArtists)
                .HasForeignKey(o => o.TitleId);

            titleArtist.HasRequired(o => o.Artist)
                .WithMany(o => o.TitleArtists)
                .HasForeignKey(o => o.ArtistId);

            titleArtist.HasRequired(o => o.Role)
                .WithMany(o => o.TitleArtists)
                .HasForeignKey(o => o.RoleId);

            titleArtist.Property(o => o.TitleId)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_TitleArtist_TitleId")));

            titleArtist.Property(o => o.ArtistId)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_TitleArtist_ArtistId")));

            titleArtist.Property(o => o.RoleId)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_TitleArtist_RoleId")));

            //
            // Configure TitleArtistCharacter
            //

            var titleArtistCharacter = modelBuilder.Entity<TitleArtistCharacter>()
                .HasKey(o => o.Id);

            titleArtistCharacter.Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            titleArtistCharacter.HasRequired(o => o.TitleArtist)
                .WithMany(o => o.TitleArtistCharacters)
                .HasForeignKey(o => o.TitleArtistId);

            titleArtistCharacter.HasRequired(o => o.Character)
                .WithMany(o => o.TitleArtistCharacters)
                .HasForeignKey(o => o.CharacterId);

            titleArtistCharacter.Property(o => o.TitleArtistId)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_TitleArtistCharacter_TitleArtistId")));

            titleArtistCharacter.Property(o => o.CharacterId)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_TitleArtistCharacter_CharacterId")));

            //
            // Configure TitleGenre
            //

            var titleGenre = modelBuilder.Entity<TitleGenre>()
                .HasKey(o => o.Id);

            titleGenre.Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            titleGenre.HasRequired(o => o.Title)
                .WithMany(o => o.TitleGenres)
                .HasForeignKey(o => o.TitleId);

            titleGenre.HasRequired(o => o.Genre)
                .WithMany(o => o.TitleGenres)
                .HasForeignKey(o => o.GenreId);

            titleGenre.Property(o => o.TitleId)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_TitleGenre_TitleId")));

            titleGenre.Property(o => o.GenreId)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_TitleGenre_GenreId")));

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}