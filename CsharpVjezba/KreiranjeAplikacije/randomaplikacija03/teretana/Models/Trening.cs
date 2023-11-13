using System.ComponentModel.DataAnnotations.Schema;

namespace teretana.Models
{
    public class Trening : Entitet
    {
        public string Naziv { get; set; }
        public int BrojSerija { get; set; }
        public int BrojPonavljanja { get; set; }

        public List<Korisnik> Korisnici { get; set; } = new();
        [ForeignKey("oprema")]
        public Oprema Oprema { get; set; }
    }
}
