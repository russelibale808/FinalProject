using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Data
{
    public class RusselContext : DbContext
    {
        public RusselContext(DbContextOptions<RusselContext> options) : base(options) { }


        public DbSet<Image> Images { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }                                                                  
    }
}
