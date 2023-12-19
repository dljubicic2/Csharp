using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace randomaplikacijazoloskivrt.Models
{
    public class Zivotinja : Entitet
    {
        public string? Vrsta { get; set; }
        public string? Naziv { get; set; }

        [ForeignKey("djelatnik")]
        public Djelatnik? Djelatnik { get; set; }

        public List<Prostorija> Prostorije { get; set; } = new();

        
        

    }
}
