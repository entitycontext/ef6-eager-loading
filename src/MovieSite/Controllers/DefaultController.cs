using System;
using System.Web.Mvc;

using MovieSite.Database;

namespace MovieSite.Controllers
{
    public class DefaultController : Controller
    {
        public const string MODE_INCLUDE = "include";
        public const string MODE_LAZY = "lazy";
        public const string MODE_MANUAL = "manual";
        public const string MODE_SPROC = "sproc";
        public const string MODE_CACHE = "cache";

        private IRepository _repo;
        private IRepository GetRepo()
        {
            if (_repo == null && Request != null)
            {
                var db = new DatabaseContext();

                switch (Request["mode"])
                {
                    case MODE_INCLUDE:
                        _repo = new RepositoryExplicitInclude(db);
                        break;

                    case MODE_LAZY:
                        _repo = new RepositoryLazy(db);
                        break;

                    case MODE_SPROC:
                        _repo = new RepositoryStoredProcedures(db);
                        break;

                    case MODE_CACHE:
                        _repo = new RepositoryEntityCache(db);
                        break;

                    case MODE_MANUAL:
                    default:
                        _repo = new RepositoryExplicitManual(db);
                        break;
                }

                //
                // NOTE: We're adding the repo to the HTTP context so we can dispose of it from Application_EndRequest.
                //
                HttpContext.Items["repo"] = _repo;
            }
            return _repo;
        }

        [Route("")]
        public ActionResult Index()
        {
            ViewBag.Title = "Movie Site";
            return View();
        }

        [Route("artists/{artistId}")]
        public ActionResult ArtistDetails(
            long artistId)
        {
            var repo = GetRepo();
            var artist = repo?.GetArtist(artistId);
            if (artist == null)
            {
                throw new Exception($"No artist with id #{artistId} found.");
            }
            ViewBag.Title = $"{artist.Name} Artist Details";
            return View(artist);
        }

        [Route("artists")]
        public ActionResult ArtistList()
        {
            var repo = GetRepo();
            var artists = repo?.GetArtists();
            ViewBag.Title = "Artist List";
            return View(artists);
        }

        [Route("characters/{characterId}")]
        public ActionResult CharacterDetails(
            long characterId)
        {
            var repo = GetRepo();
            var character = repo?.GetCharacter(characterId);
            if (character == null)
            {
                throw new Exception($"No character with id #{characterId} found.");
            }
            ViewBag.Title = $"{character.Name} Character Details";
            return View(character);
        }

        [Route("characters")]
        public ActionResult CharacterList()
        {
            var repo = GetRepo();
            var characters = repo?.GetCharacters();
            ViewBag.Title = "Character List";
            return View(characters);
        }

        [Route("titles/{titleId}")]
        public ActionResult TitleDetails(
            long titleId)
        {
            var repo = GetRepo();
            var title = repo?.GetTitle(titleId);
            if (title == null)
            {
                throw new Exception($"No title with id #{titleId} found.");
            }
            ViewBag.Title = $"{title.Name} Title Details";
            return View(title);
        }

        [Route("titles")]
        public ActionResult TitleList()
        {
            var repo = GetRepo();
            var titles = repo?.GetTitles();
            ViewBag.Title = "Title List";
            return View(titles);
        }
    }
}