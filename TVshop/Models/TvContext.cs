
using System.Data.Entity;


namespace TVshop.Models
{
    public class TvContext:DbContext
    {
        public DbSet<Tvshop> TvShops { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Bascket> Bascket { get; set; }
    }
}