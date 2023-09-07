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
    }
}
