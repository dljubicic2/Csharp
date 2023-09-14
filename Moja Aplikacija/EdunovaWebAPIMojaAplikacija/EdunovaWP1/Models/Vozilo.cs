using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaWP1.Models
{
    public class Vozilo : Entitet
    {
        public string? Marka { get; set; }
        public string? Model { get; set; }
        public string? Pogon { get; set; }
        public DateTime Godiste { get; set; }
        public int Kilometraza { get; set; }
        [ForeignKey("osoba")]
        public Osoba? Osoba { get; set; }

    }
}
