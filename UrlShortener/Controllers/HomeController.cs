using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UrlShortener.Models;
using UrlShortener.Models.ViewModel;

namespace UrlShortener.Controllers
{
    public class HomeController : Controller
    {
        

        private SiteContext db = new SiteContext();
        // GET: Home
        public ActionResult Create()
        {
            ShWM sh = new ShWM { ShortenerList = db.Shortener.ToList() };
            return View(sh);
        }

        [HttpPost]
        public ActionResult Create(ShWM shotner)
        {
            

            bool kisaUrlVarMi = false;
            do
            {
                string shotUrl = "";
                Random rnd = new Random();
                List<string> dizi = new List<string>();
                List<char> UpperLetter = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                List<char> LowerLetter = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                for (int i = 0; i < 6; i++)
                {
                    int index = rnd.Next(0, 25);
                    shotUrl += rnd.Next(0, 26) % 2 == 0

                        ? UpperLetter[index].ToString()

                        : LowerLetter[index].ToString();
                }

                string newShUrl = Request.Url.OriginalString + "url/" + shotUrl;
                kisaUrlVarMi = db.Shortener.SingleOrDefault(kisaUrl => kisaUrl.ShortUrl == newShUrl) != null;

                if (!kisaUrlVarMi)
                {
                    bool a = shotner.Shortener.LongUrl.Contains("http://") ||
                             shotner.Shortener.LongUrl.Contains("https://");
                    shotner.Shortener.LongUrl = a ? shotner.Shortener.LongUrl : "http://" + shotner.Shortener.LongUrl;
                    shotner.Shortener.ShortUrl = newShUrl;
                    db.Shortener.Add(shotner.Shortener);
                    db.SaveChanges();
                }

            } while (kisaUrlVarMi);

            shotner.ShortenerList = db.Shortener.ToList();
            return View(shotner);
        }

        public ActionResult url()
        {
            // Burada gelen url'yi get metodu ile yakalayıp sorgumu değiştirerek databasede kontrol ettirsem de olur.
            string url = Request.Url.OriginalString;
            var sh = db.Shortener.SingleOrDefault(kisaUrl => kisaUrl.ShortUrl == url);
            return Redirect(sh.LongUrl);
        }
    }
}