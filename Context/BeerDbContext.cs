using Microsoft.EntityFrameworkCore;

namespace BeerDBWebApplication.Context
{
    public class BeerDbContext : DbContext
    {
        public BeerDbContext()
        {

        }

        public BeerDbContext(DbContextOptions<BeerDbContext> options ) : base (options)
        {


        }
        public DbSet<BeerDBWebApplication.Model.beers> beers { get; set; }
    }
}
