using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class Upit : Object
    {
        public int Sifra { get; set; }
        public int Oglas { get; set; }
        public string Pitanje { get; set; }
        public DateTime VrijemeUpita { get; set; }
        public int Osoba { get; set; }

 
    }
}
