using System.Collections.Generic;
using System.Web.Mvc;

using MovieSite.Models;

namespace MovieSite.Controllers
{
    public class DefaultController : Controller
    {
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
            ViewBag.Title = "Artist Details";
            return View(new Artist());
        }

        [Route("artists")]
        public ActionResult ArtistList()
        {
            ViewBag.Title = "Artist List";
            return View(new List<Artist>());
        }

        [Route("characters/{characterId}")]
        public ActionResult CharacterDetails(
            long characterId)
        {
            ViewBag.Title = "Character Details";
            return View(new Character());
        }

        [Route("characters")]
        public ActionResult CharacterList()
        {
            ViewBag.Title = "Character List";
            return View(new List<Character>());
        }

        [Route("titles/{titleId}")]
        public ActionResult TitleDetails(
            long titleId)
        {
            ViewBag.Title = "Title Details";
            return View(new Title());
        }

        [Route("titles")]
        public ActionResult TitleList()
        {
            ViewBag.Title = "Title List";
            return View(new List<Title>());
        }
    }
}