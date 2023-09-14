using EdunovaWP1.Models;
using Microsoft.EntityFrameworkCore;

namespace EdunovaWP1.Data
{
    public class EdunovaContext : DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> opcije) 
            : base(opcije) {
            
        }
        public DbSet<Osoba> Osoba { get; set; }
        public DbSet<Vozilo> Vozilo { get; set; }
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vozilo>().HasOne(o => o.Osoba);

            modelBuilder.Entity<Oglas>().HasOne(o => o.Osoba);

            modelBuilder.Entity<Upit>()
                .HasMany(u => u.Osoba);
                
                
                
        }
    }
}
