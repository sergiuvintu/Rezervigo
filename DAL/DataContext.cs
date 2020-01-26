using Rezervigo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace Rezervigo.DAL
{
    public class DataContext : DbContext
    {

        public DataContext() : base("DefaultConnection")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User>  Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Reservation>().HasRequired(s => s.User);
            modelBuilder.Entity<Reservation>().HasRequired(s => s.Room);
        }
    }
}