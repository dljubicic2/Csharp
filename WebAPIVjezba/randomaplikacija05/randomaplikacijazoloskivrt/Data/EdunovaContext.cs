using Microsoft.EntityFrameworkCore;
using randomaplikacijazoloskivrt.Models;

namespace randomaplikacijazoloskivrt.Data
{
    public class EdunovaContext : DbContext
    {
        public EdunovaContext(DbContextOptions <EdunovaContext> opcije)
            :base(opcije){

            

        }

        public DbSet<Djelatnik> Djelatnik { get; set; }
        public DbSet<Prostorija> Prostorija { get; set; }

        public DbSet<Zivotinja> Zivotinja { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zivotinja>()
                .HasMany(z => z.Djelatnici)
                .WithMany(d => d.Zivotinje)
                .UsingEntity<Dictionary<string, object>>("datum",
                da => da.HasOne<Djelatnik>().WithMany().HasForeignKey("djelatnik"),
                da => da.HasOne<Zivotinja>().WithMany().HasForeignKey("zivotinja"),
                da => da.ToTable("datum")
                );

            modelBuilder.Entity<Zivotinja>()
                .HasMany(z => z.Prostorije)
                .WithMany(p => p.Zivotinje)
                .UsingEntity<Dictionary<string, object>>("datum",
                da => da.HasOne<Prostorija>().WithMany().HasForeignKey("prostorija"),
                da => da.HasOne<Zivotinja>().WithMany().HasForeignKey("zivotinja"),
                da => da.ToTable("datum")
                );

            modelBuilder.Entity<Zivotinja>().HasOne(z => z.Datum);
        }
    }

    
}
