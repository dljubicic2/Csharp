using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaWP1.Models
{
    public class Upit : Entitet
    {
        public string? Pitanje { get; set; }
        [ForeignKey("oglas")]
        public Oglas? Oglas { get; set; }
        [ForeignKey("osoba")]
        public Osoba? Osoba { get; set; }
    }
}
