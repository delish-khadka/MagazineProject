using Microsoft.EntityFrameworkCore;
using MagazineProject.Models;

namespace MagazineProject.Data
{

    public class MagazineDbContext: DbContext
    {
        public MagazineDbContext(DbContextOptions<MagazineDbContext> options) : base(options) { }

        public DbSet<Advertisement> Advertisement { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Journal> Journal { get; set; }
        public DbSet<News> News { get; set; }
    }
}
