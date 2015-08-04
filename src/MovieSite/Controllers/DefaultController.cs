using System;
using System.Web.Mvc;

using MovieSite.Database;
using MovieSite.Models;

namespace MovieSite.Controllers
{
    public class DefaultController : Controller
    {
        public const string MODE_INCLUDE = "include";
        public const string MODE_MANUAL = "manual";

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

                    case MODE_MANUAL:
                    default:
                        _repo = new RepositoryExplicitManual(db);
                        break;
                }
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
            var artist = GetRepo()?.GetArtist(artistId);
            if (artist == null)
            {
                throw new Exception($"No artist with id #{artistId} found.");
            }

            ViewBag.Title = $"{artist.Name} Artist Details";
            return View(new Artist());
        }

        [Route("artists")]
        public ActionResult ArtistList()
        {
            var artists = GetRepo()?.GetArtists();
            ViewBag.Title = "Artist List";
            return View(artists);
        }

        [Route("characters/{characterId}")]
        public ActionResult CharacterDetails(
            long characterId)
        {
            var character = GetRepo()?.GetCharacter(characterId);
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
            var characters = GetRepo()?.GetCharacters();
            ViewBag.Title = "Character List";
            return View(characters);
        }

        [Route("titles/{titleId}")]
        public ActionResult TitleDetails(
            long titleId)
        {
            var title = GetRepo()?.GetTitle(titleId);
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
            var titles = GetRepo()?.GetTitles();
            ViewBag.Title = "Title List";
            return View(titles);
        }
    }
}