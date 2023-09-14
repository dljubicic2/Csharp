using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaWP1.Models
{
    public class Oglas : Entitet
    {
        public string? Naslov { get; set; }
        public string? Opis { get; set; }
        public decimal Cijena { get; set; }
        [ForeignKey("osoba")]
        public Osoba? Osoba { get; set; }

        [ForeignKey("vozilo")]
        public Vozilo? Vozilo { get; set; } = new();
    }
}
