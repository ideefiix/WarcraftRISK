using Microsoft.EntityFrameworkCore;
using WarcraftApi.Entities;

namespace WarcraftApi.Context
{
    public class DBcontext : DbContext
    {

        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        {
            
        }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Tile> Tiles { get; set; }

        public virtual DbSet<SpyReport> SpyReports {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Tile>().ToTable("Tile");
            modelBuilder.Entity<SpyReport>().ToTable("SpyReport");
        }
    }
    
}