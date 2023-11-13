using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teretana.Models;

namespace teretana.Data
{
    public class EdunovaContext : DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> opcije) 
        
            : base(opcije) {

            }

        public DbSet<Korisnik> Korisnik { get; set; } 
        public DbSet<Oprema> Oprema { get; set; }
        public DbSet<Trening> Trening { get; set; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trening>().HasOne(o => o.Oprema);

            modelBuilder.Entity<Trening>()
                .HasMany(k => k.Korisnici)
                .WithMany(t => t.Treninzi)
                .UsingEntity<Dictionary<string, object>>("clan",
                c => c.HasOne<Korisnik>().WithMany().HasForeignKey("korisnik"),
                c => c.HasOne<Trening>().WithMany().HasForeignKey("trening"),
                c => c.ToTable("clan"));

            
                
                
        }




    }
}
