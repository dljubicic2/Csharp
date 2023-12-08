using Microsoft.EntityFrameworkCore;

namespace randomaplikacijazoloskivrt.Data
{
    public class EdunovaContext : DbContext
    {
        public EdunovaContext(DbContextOptions <EdunovaContext> opcije)
            :base(opcije){

        }
    }
}
