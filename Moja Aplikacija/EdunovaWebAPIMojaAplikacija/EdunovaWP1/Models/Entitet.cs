using System.ComponentModel.DataAnnotations;

namespace EdunovaWP1.Models
{
    public abstract class Entitet
    {
        [Key]
        public int Sifra { get; set; }
    }
}
