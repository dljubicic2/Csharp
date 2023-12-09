using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace randomaplikacijazoloskivrt.Models
{
    public class Zivotinja : Entitet
    {
        public string? Vrsta { get; set; }
        public string? Naziv { get; set; }
        public List<Djelatnik> Djelatnici { get; set; }
        public List<Prostorija> Prostorije { get; set; }

        
        public Datum? Datum { get; set; }

    }
}
