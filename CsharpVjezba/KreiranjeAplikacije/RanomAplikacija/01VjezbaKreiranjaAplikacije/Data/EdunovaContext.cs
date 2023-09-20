using Microsoft.EntityFrameworkCore;

namespace _01VjezbaKreiranjaAplikacije.Data
{
    public class EdunovaContext : DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> opcije)
             : base(opcije)
        {
            
        }







    }
}
