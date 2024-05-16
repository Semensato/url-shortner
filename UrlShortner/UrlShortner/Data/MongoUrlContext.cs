using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.EntityFrameworkCore.Extensions;

namespace UrlShortner.Data
{
    public class MongoUrlContext : DbContext
    {
        public DbSet<ShortenedUrl> ShortnedUrls { get; set; }

        public MongoUrlContext(DbContextOptions<MongoUrlContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShortenedUrl>().ToCollection("shortnedUrls");
        }

    }
}
