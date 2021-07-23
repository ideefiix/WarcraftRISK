using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WarcraftApi.Entities;

namespace WarcraftApi.Context
{
    public class DBcontext : DbContext
    {

        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        {
            
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Tile> Tiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Tile>().ToTable("Tile");
        }
    }
    
}