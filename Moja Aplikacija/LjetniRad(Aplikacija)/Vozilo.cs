using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class Vozilo :Entitet
    {
        public string Vrsta { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Pogon { get; set; }
        public DateTime Godiste { get; set; }
        public int Kilometraza { get; set; }
        public List<Osoba> Osobe { get; set; } 
    }
}
