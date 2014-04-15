using KidChores2.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidChores2.Data
{
    public class KidChore2Context : DbContext
    {
        public DbSet<Kid> Kids { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<KidRoom> KidRooms { get; set; }
    }
}
