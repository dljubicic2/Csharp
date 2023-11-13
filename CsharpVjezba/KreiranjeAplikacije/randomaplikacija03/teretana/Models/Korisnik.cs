using System.ComponentModel.DataAnnotations.Schema;

namespace teretana.Models
{
    public class Korisnik : Entitet
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int BrojIskaznice { get; set; }
       


        public ICollection<Trening> Treninzi { get; } = new List<Trening>();
    }
}
