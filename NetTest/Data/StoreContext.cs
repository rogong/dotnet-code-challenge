using NetTest.Entities;
using Microsoft.EntityFrameworkCore;


namespace NetTest.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CarOwnerInfo> CarOwnerInfos { get; set; }
        public DbSet<FuellingStation> FuellingStations { get; set; }
    }
}
