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
            modelBuilder.Entity<Zivotinja>().HasOne(d => d.Djelatnik);

            modelBuilder.Entity<Zivotinja>()
                .HasMany(z => z.Prostorije)
                .WithMany(p => p.Zivotinje)
                .UsingEntity<Dictionary<string, object>>("datum",
                da => da.HasOne<Prostorija>().WithMany().HasForeignKey("prostorija"),
                da => da.HasOne<Zivotinja>().WithMany().HasForeignKey("zivotinja"),
                da => da.ToTable("datum")
                );

            
        }
    }

    
}
