using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UrlShortener.Models
{
    public class SiteContext : DbContext
    {
        //webConfig deki ConnectionString'i aldık
        public static string conn = ConfigurationManager.ConnectionStrings["ShortenerConStr"].ConnectionString;

        public SiteContext() : base(conn)
        {
            Database
               .SetInitializer(new MigrateDatabaseToLatestVersion<SiteContext, Migrations.Configuration>(true));
        }

        public virtual DbSet<Shortener> Shortener { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //tablo sonu 's' kaldırır
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }
}