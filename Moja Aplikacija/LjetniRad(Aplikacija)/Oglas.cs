using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class Oglas : Entitet
    {
        public List<Vozilo> Vozila { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
        public List<Osoba> Osobe { get; set; }
        public DateTime VrijemeIzrade { get; set; }
        public decimal Cijena { get; set; }
    }
}
