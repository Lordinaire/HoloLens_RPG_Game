using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebServer.Data
{
    public interface IDataContext
    {
        DbSet<MapType> MapTypes { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<Map> Maps { get; set; }

        int SaveChanges();

        EntityEntry Entry(object entity);
    }
}
