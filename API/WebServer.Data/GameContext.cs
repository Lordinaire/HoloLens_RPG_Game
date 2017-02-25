using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebServer.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<MapType> MapTypes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Map> Maps { get; set; }
        
        public DataContext(DbContextOptions<DataContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(game =>
            {
                game.HasKey(p => p.Id);
                game.ToTable("Games");
            });

            modelBuilder.Entity<Map>(map =>
            {
                map.HasKey(c => c.Id);
                map.ToTable("Maps");

                map.Ignore(p => p.Items);
            });

            modelBuilder.Entity<MapType>(mapType =>
            {
                mapType.HasKey(c => c.Id);
                mapType.ToTable("MapTypes");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
