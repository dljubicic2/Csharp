using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace RandomAplikacija01.Data
{
    public class EdunovaContext : DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> opcije)
                : base(opcije)
        {

        }
    }
}
