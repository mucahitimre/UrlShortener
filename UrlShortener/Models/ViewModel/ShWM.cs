using System.Collections.Generic;

namespace UrlShortener.Models.ViewModel
{
    public class ShWM
    {
        public Shortener Shortener { get; set; }
        public List<Shortener> ShortenerList { get; set; }
    }
}