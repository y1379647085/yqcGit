using MyMvcStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcStudy.Controllers
{
    public class HomeController : Controller
    {
        private MusicStoreEntities storeDB = new MusicStoreEntities();
        public ActionResult Index()
        {
            //return View();
            var albums = GetTopSellingAlbums(6);

            return View(albums);
        }

        public ActionResult ArtistSearch(string q)
        {
            var artists = GetArtists(q);
            return PartialView(artists);
        }
        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count

            return storeDB.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public ActionResult QuickSearch(string term)
        {
            var artists = GetArtists(term).Select(a => new { value = a.Name });
            return Json(artists, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DailyDeal()
        {
            var album = GetDailyDeal();
            return PartialView("_DailyDeal", album);
        }
        private Album GetDailyDeal()
        {
            var album = storeDB.Albums
                .OrderBy(a => System.Guid.NewGuid())
                .First();
            album.Price *= 0.5m;
            return album;
        }

        private List<Artist> GetArtists(string searchString)
        {
            return storeDB.Artists.Where(a => a.Name.Contains(searchString))
                .ToList();
        }
    }
}