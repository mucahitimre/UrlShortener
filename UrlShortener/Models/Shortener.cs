using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class Shortener
    {
        public Shortener()
        {
            CreateTime = DateTime.Now;
        }

        [Key]
        public int ShortenerId { get; set; }

        [Display(Name = "Uzun Url"), DataType(DataType.Url, ErrorMessage = "Lütfen geçerli bir url giriniz.")]
        public string LongUrl { get; set; }

        [Display(Name = "Kısa Url'niz")]
        public string ShortUrl { get; set; }

        public DateTime CreateTime { get; set; }
    }
}